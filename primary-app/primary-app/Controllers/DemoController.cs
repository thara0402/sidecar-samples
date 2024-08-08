using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace primary_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            var response = "Hello Gooner!";
            return Ok(response);
        }
    }
}
