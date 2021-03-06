﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PicPay.Application.ViewModel.HAL;
using PicPay.Application.ViewModel.Post;

namespace PicPay.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ApiController
    {
        // GET api/users/065d8403-8a8f-484d-b602-9138ff7dedcf
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var response = new Application.ViewModel.Get.UserViewModel
            {
                Id = Guid.NewGuid(),
                Nome = "Foo",
                Username = "Bar"
            };
            var links = new Dictionary<string, string> { { "self", $"/api/users/{id}" } };
            return Response(response, links);
        }

        // GET /api/users/q/{paramter-query}/page/{page}
        [HttpGet, Route("q/{query}/page/{page}")]
        public IActionResult GetByParams(string query, int page)
        {
            var hal = new ListItemsInHalJsonViewModel
            {
                Content = new List<Application.ViewModel.Get.UserViewModel>
                {
                    new Application.ViewModel.Get.UserViewModel{
                        Id = Guid.NewGuid(),
                        Nome = "Foo",
                        Username = "Bar"
                    },
                    new Application.ViewModel.Get.UserViewModel{
                        Id = Guid.NewGuid(),
                        Nome = "Foo",
                        Username = "Bar"
                    }
                },
                Total = 2,
                TotalPerPage = 2,
                ContentListName = "usuarios",
                SelfRouter = "api/users/q/{query}/page/{page}",
                ItemRouter = "api/users/{id}",
                Paramters = new Dictionary<string, string> { { "{query}", query }, { "{page}", page.ToString() } }
            };
            return Response(hal);
        }

        [HttpPost]
        public IActionResult Post([FromBody]UserViewModel user)
        {
            ModelState.AddModelError("NI", "Função não necessária para api de teste seletivo Pic Pay");
            NotifyModelStateErrors();
            return Response();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UserViewModel user)
        {
            ModelState.AddModelError("NI", "Função não necessária para api de teste seletivo Pic Pay");
            NotifyModelStateErrors();
            return Response();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            ModelState.AddModelError("NI", "Função não necessária para api de teste seletivo Pic Pay");
            NotifyModelStateErrors();
            return Response();
        }
    }
}
