using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Web_App.Pages.Teacher.ClassManagement
{
    [Authorize(Roles = "Teacher")]
    public class IndexModel : PageModel
    {
        public string? UserId { get; set; }
        public string? Token { get; set; }

        public void OnGet()
        {
            ViewData["Title"] = "Quản lý lớp";
            ViewData["ActiveMenu"] = "ClassManagement";

            UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Token = User.FindFirst("Token")?.Value;
        }
    }
}
