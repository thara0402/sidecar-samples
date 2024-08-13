using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace primary_app.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class GenerateController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public GenerateController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] string prompt)
        {
            var sidecarUrl = _configuration["SIDECAR_SLM_URL"];
            var json = @"
            {
                ""model"": ""phi3"",
                ""prompt"": """ + prompt + @""",
                ""stream"": false,
                ""options"": {
                    ""num_keep"": 5,
                    ""num_predict"": 150,
                    ""seed"": 42,
                    ""top_k"": 1,
                    ""top_p"": 0.9,
                    ""tfs_z"": 0.5,
                    ""typical_p"": 0.7,
                    ""repeat_last_n"": 33,
                    ""temperature"": 0.8,
                    ""repeat_penalty"": 1.2,
                    ""presence_penalty"": 1.5,
                    ""frequency_penalty"": 1.0,
                    ""mirostat"": 1,
                    ""mirostat_tau"": 0.8,
                    ""mirostat_eta"": 0.6,
                    ""penalize_newline"": true,
                    ""stop"": [""<*end*>""],
                    ""num_thread"": 8
                }
            }";

            var httpClient = _httpClientFactory.CreateClient();
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(sidecarUrl, content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return Ok(responseContent);
            }
            else
            {
                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
