using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_App.Pages
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            // Tự động chuyển hướng sang trang Quản lý người dùng
            return RedirectToPage("/Admin/Users");
        }
    }
}
