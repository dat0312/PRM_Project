using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;

namespace Web_App.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/web/notification")]
    public class NotificationBffController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NotificationBffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient GetClient()
        {
            var client = _httpClientFactory.CreateClient("BackendApi");
            var token = User.FindFirst("Token")?.Value;
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
            return client;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotifications([FromQuery] int page = 1, [FromQuery] int pageSize = 100)
        {
            var client = GetClient();
            var response = await client.GetAsync($"/api/notification?page={page}&pageSize={pageSize}");
            var content = await response.Content.ReadAsStringAsync();
            return StatusCode((int)response.StatusCode, content);
        }

        [HttpPut("{id}/read")]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            var client = GetClient();
            var emptyContent = new StringContent("", Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/api/notification/{id}/read", emptyContent);
            return StatusCode((int)response.StatusCode);
        }
    }
}
