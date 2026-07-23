using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Web_App.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/web/class")]
    public class ClassBffController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ClassBffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient GetClient()
        {
            var client = _httpClientFactory.CreateClient("BackendApi");
            var token = User.FindFirst("Token")?.Value;
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            return client;
        }

        [HttpGet("my-classes")]
        public async Task<IActionResult> GetMyClasses([FromQuery] string? academicYear)
        {
            var client = GetClient();
            var url = "/api/class/my-classes";
            if (!string.IsNullOrEmpty(academicYear))
            {
                url += $"?academicYear={academicYear}";
            }
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }
    }
}
