using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Web_App.Pages.Teacher.Requests
{
    [Authorize(Roles = "Teacher")]
    public class IndexModel : PageModel
    {
        public string? UserId { get; set; }
        public string? Token { get; set; }

        public void OnGet()
        {
            ViewData["Title"] = "Đơn từ";
            ViewData["ActiveMenu"] = "Requests";

            UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Token = User.FindFirst("Token")?.Value;
        }
    }
}
