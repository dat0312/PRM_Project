using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_App.Pages.Teacher.Grades
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            var token = User.FindFirst("Token")?.Value;
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToPage("/Login");
            }
            ViewData["ActiveMenu"] = "Grades";
            return Page();
        }
    }
}
