using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace sidecar_dotnetcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            var response = "Hello Sidecar!";
            return Ok(response);
        }
    }
}
