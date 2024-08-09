using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace primary_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public DemoController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            var url = _configuration["SIDECAR_URL"];
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetStringAsync(url);
            return Ok(response);
        }
    }
}
