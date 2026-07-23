using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Web_App.Pages
{
    [Authorize]
    public class NotificationsModel : PageModel
    {
        public string UserRole { get; set; } = "Student";

        public void OnGet()
        {
            if (User.IsInRole("Admin"))
            {
                UserRole = "Admin";
            }
            else if (User.IsInRole("Teacher"))
            {
                UserRole = "Teacher";
            }
            ViewData["ActiveMenu"] = "Notifications";
        }
    }
}
