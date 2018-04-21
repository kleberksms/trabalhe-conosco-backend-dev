using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Halcyon.HAL;
using Halcyon.Web.HAL;
using PicPay.Application.ViewModel.Get;
using PicPay.Application.ViewModel.HAL;

namespace PicPay.Controllers
{
    public class ApiController : Controller
    {
        private readonly List<string> _modelStateErrors;

        public ApiController()
        {
            _modelStateErrors = new List<string>();
        }

        protected void NotifyModelStateErrors()
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                var erroMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                NotifyError(erroMsg);
            }
        }

        private void NotifyError(string erroMsg)
        {
            _modelStateErrors.Add(erroMsg);
        }

        protected new IActionResult Response(object result = null, Dictionary<string, string> links = null)
        {
            if (_modelStateErrors.Any())
            {
                return BadRequest(new
                {
                    success = false,
                    errors = _modelStateErrors
                });
            }

            var halLinks = new List<Link>();
            if (links == null)
            {
                return this.HAL(result, halLinks);
            }

            foreach (var kp in links)
            {
                halLinks.Add(new Link(kp.Key, kp.Value));
            }

            return this.HAL(result, halLinks);
        }

        /**
         * Por questões de tempo acabei forçando o tipo no método,
         * tenho poucas coisas com HALJson por normalmente RestFul (somente Rest) não é minha realidade de trabalho =/
         * @todo Corrigir esta quesão do next
         */
        protected new IActionResult Response(ListItemsInHalJsonViewModel result)
        {
            if (_modelStateErrors.Any())
            {
                return BadRequest(new
                {
                    success = false,
                    errors = _modelStateErrors
                });
            }

            var halLinks = new List<Link>();
            var existPage = result.SelfRouter.Contains("{page}") && result.Paramters.ContainsKey("{page}");
            if (existPage)
            {
                halLinks.Add(new Link("next", result.SelfRouter.Replace("{page}", (Convert.ToInt32(result.Paramters.SingleOrDefault(c => c.Key.Equals("{page}")).Value) + 1).ToString())));
            }

            var self = result.SelfRouter;
            foreach (var kp in result.Paramters)
            {
                self = self.Replace(kp.Key, kp.Value);
            }

            return this.HAL(
                new { total = result.Total, perPage = result.TotalPerPage },
                new Link("self", self),
                result.ContentListName,
                result.Content as List<UserViewModel>,
                halLinks);
        }

    }
}
