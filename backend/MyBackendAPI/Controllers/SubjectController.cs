using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBackendAPI.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyBackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SubjectController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SubjectController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetSubjects([FromQuery] int? grade, [FromQuery] string? group)
        {
            var query = _context.Subjects.AsQueryable();
            
            if (grade.HasValue)
                query = query.Where(s => s.Grade == grade.Value);
                
            if (!string.IsNullOrEmpty(group))
                query = query.Where(s => s.Group == group);

            var subjects = await query
                .Select(s => new
                {
                    s.Id,
                    s.Code,
                    s.Name,
                    s.Grade,
                    s.Group
                })
                .ToListAsync();

            return Ok(subjects);
        }

        [HttpGet("{subjectId}/teachers")]
        public async Task<IActionResult> GetTeachersBySubject(int subjectId)
        {
            var teachers = await _context.TeacherSubjects
                .Include(ts => ts.Teacher)
                .Where(ts => ts.SubjectId == subjectId)
                .Select(ts => new
                {
                    ts.Teacher.Id,
                    ts.Teacher.FullName,
                    ts.Teacher.Email
                })
                .ToListAsync();

            return Ok(teachers);
        }
    }
}
