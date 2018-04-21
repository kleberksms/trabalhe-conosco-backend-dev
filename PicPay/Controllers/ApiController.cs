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

            var contentLinks = new List<Link>();
            var embbedLinks = new List<Link>();
            foreach (var user in (List<UserViewModel>)result.Content)
            {
                embbedLinks.Add(new Link("self", result.ItemRouter.Replace("{id}", user.Id.ToString())));
            }

            var self = result.SelfRouter;
            var next = result.SelfRouter;
            foreach (var kp in result.Paramters)
            {
                if (kp.Key.Equals("{page}"))
                {
                    next = self.Replace(kp.Key, (Convert.ToInt32(kp.Value) + 1).ToString());
                }
                self = self.Replace(kp.Key, kp.Value);
            }

            contentLinks.Add(new Link("self", self));
            contentLinks.Add(new Link("next", next));

            return this.HAL(
                new { total = result.Total, perPage = result.TotalPerPage },
                contentLinks,
                result.ContentListName,
                (List<UserViewModel>) result.Content,
                embbedLinks);
        }

    }
}
