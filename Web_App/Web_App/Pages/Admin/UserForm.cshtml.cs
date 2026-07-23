using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_App.Pages.Admin
{
    public class UserFormModel : PageModel
    {
        public void OnGet()
        {
            ViewData["Title"] = "Thêm/Sửa người dùng";
            ViewData["ActiveMenu"] = "Users";
        }
    }
}
