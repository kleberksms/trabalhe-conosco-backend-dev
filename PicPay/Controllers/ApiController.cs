using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
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
                NotifyError( erroMsg);
            }
        }

        private void NotifyError(string erroMsg)
        {
            _modelStateErrors.Add(erroMsg);
        }

        protected new IActionResult Response(object result = null)
        {
            if (_modelStateErrors.Any())
            {
                return BadRequest(new
                {
                    success = false,
                    errors = _modelStateErrors
                });
            }

            var data = new
            {
                success = true,
                data = result
            };

            return Ok(data);
        }

        protected new IActionResult Response(ListItemsInHalJsonViewModel result = null)
        {
            if (_modelStateErrors.Any())
            {
                return BadRequest(new
                {
                    success = false,
                    errors = _modelStateErrors
                });
            }

            var data = new
            {
                success = true,
                data = result
            };

            return Ok(data);
        }
    }
}
