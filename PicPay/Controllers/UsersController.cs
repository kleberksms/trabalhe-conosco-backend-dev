using Microsoft.AspNetCore.Mvc;
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
            return Response();
        }

        // GET /api/users/q/{paramter-query}/page/{page}
        [HttpGet, Route("q/{query}/page/{page}")]
        public IActionResult GetByParams(string query, int page)
        {
            return Response();
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
            ModelState.AddModelError("NI","Função não necessária para api de teste seletivo Pic Pay");
            NotifyModelStateErrors();
            return Response();
        }
    }
}
