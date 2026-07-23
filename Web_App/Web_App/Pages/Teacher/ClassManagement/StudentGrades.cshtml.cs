using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Web_App.Pages.Teacher.ClassManagement
{
    [Authorize(Roles = "Teacher")]
    public class StudentGradesModel : PageModel
    {
        public string? Token { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public int StudentId { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string StudentName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Semester { get; set; }

        public void OnGet()
        {
            ViewData["Title"] = "Chi tiết điểm số";
            ViewData["ActiveMenu"] = "ClassManagement";
            Token = User.FindFirst("Token")?.Value;
        }
    }
}
