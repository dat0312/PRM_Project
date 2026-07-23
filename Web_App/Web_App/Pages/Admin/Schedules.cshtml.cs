using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_App.Pages.Admin
{
    public class SchedulesModel : PageModel
    {
        public void OnGet()
        {
            ViewData["Title"] = "Lịch học";
        }
    }
}
