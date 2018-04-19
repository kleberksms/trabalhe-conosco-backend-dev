using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PicPay.Application.ViewModel.Post;

namespace PicPay.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {

        // GET api/users/065d8403-8a8f-484d-b602-9138ff7dedcf
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok();
        }

        // GET /api/users?q=whatever
        [HttpGet]
        public IActionResult GetByParams([FromQuery]string q)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody]UserViewModel user)
        {
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UserViewModel user)
        {
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok();
        }
    }
}
