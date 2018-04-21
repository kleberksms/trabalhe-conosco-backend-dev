using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

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

        protected new IActionResult Response(HttpMethod method = HttpMethod.Get, object result = null)
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

            switch (method)
            {
                case HttpMethod.Get when result == null:
                    return StatusCode(204);
                case HttpMethod.Post:
                    return StatusCode(201, data);
                case HttpMethod.Put:
                    return Ok(data);
                case HttpMethod.Delete:
                    return Ok(data);
                case HttpMethod.Head:
                    return Ok(data);
                case HttpMethod.Trace:
                    return Ok(data);
                case HttpMethod.Patch:
                    return Ok(data);
                case HttpMethod.Connect:
                    return Ok(data);
                case HttpMethod.Options:
                    return Ok(data);
                case HttpMethod.Custom:
                    return Ok(data);
                default:
                    return Ok(data);
            }
        }
    }
}
