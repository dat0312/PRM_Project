using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBackendAPI.Data;
using MyBackendAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClassController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClassController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<object>>> GetClasses([FromQuery] string? academicYear)
        {
            var classes = await _context.Classes.Include(c => c.HomeroomTeacher).ToListAsync();
            return Ok(classes.Select(c => {
                string computedName = c.Name;
                if (!string.IsNullOrEmpty(academicYear) && c.StartYear > 0)
                {
                    var years = academicYear.Split('-');
                    if (years.Length == 2 && int.TryParse(years[0], out int requestedStartYear))
                    {
                        int yearDiff = requestedStartYear - c.StartYear;
                        int computedGrade = 10 + yearDiff;
                        computedName = $"{computedGrade}{c.Name}";
                        if (!string.IsNullOrEmpty(c.Cohort)) computedName += $" - {c.Cohort}";
                    }
                }
                
                if (!computedName.StartsWith(c.Grade.ToString())) {
                    computedName = $"{c.Grade}{computedName}";
                }
                
                return new {
                    c.Id,
                    Name = computedName,
                    c.Grade,
                    c.Cohort,
                    c.StartYear,
                    c.IsGradeLocked,
                    c.HomeroomTeacherId,
                    HomeroomTeacherName = c.HomeroomTeacher?.FullName
                };
            }));
        }

        [HttpGet("my-classes")]
        [Authorize(Roles = "Teacher")]
        public async Task<ActionResult<IEnumerable<Class>>> GetMyClasses([FromQuery] string? academicYear)
        {
            var userIdString = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out int userId))
                return Unauthorized();

            var schedulesQuery = _context.Schedules.Where(s => s.TeacherId == userId).AsQueryable();
            var allSchedulesForYearQuery = _context.Schedules.AsQueryable();

            if (!string.IsNullOrEmpty(academicYear))
            {
                var years = academicYear.Split('-');
                if (years.Length == 2 && int.TryParse(years[0], out int startYear) && int.TryParse(years[1], out int endYear))
                {
                    var startDate = new System.DateTime(startYear, 8, 1);
                    var endDate = new System.DateTime(endYear, 7, 31, 23, 59, 59);
                    schedulesQuery = schedulesQuery.Where(s => s.Date >= startDate && s.Date <= endDate);
                    allSchedulesForYearQuery = allSchedulesForYearQuery.Where(s => s.Date >= startDate && s.Date <= endDate);
                }
            }

            var classIds = await schedulesQuery
                .Select(s => s.ClassId)
                .Distinct()
                .ToListAsync();

            var activeClassIds = await allSchedulesForYearQuery
                .Select(s => s.ClassId)
                .Distinct()
                .ToListAsync();

            var classes = await _context.Classes
                .Include(c => c.HomeroomTeacher)
                .Where(c => classIds.Contains(c.Id) || c.HomeroomTeacherId == userId)
                .ToListAsync();

            var result = classes.Select(c => {
                string computedName = c.Name;
                if (!computedName.StartsWith(c.Grade.ToString())) {
                    computedName = $"{c.Grade}{computedName}";
                }
                if (!string.IsNullOrEmpty(c.Cohort)) computedName += $" - {c.Cohort}";
                
                return new {
                    c.Id,
                    Name = computedName,
                    c.Grade,
                    Cohort = c.Cohort,
                    c.StartYear,
                    c.IsGradeLocked,
                    c.HomeroomTeacherId,
                    HomeroomTeacherName = c.HomeroomTeacher?.FullName,
                    IsHomeroom = c.HomeroomTeacherId == userId
                };
            }).ToList();

            return Ok(result);
        }
        [HttpGet("academic-years")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<string>>> GetAcademicYears()
        {
            var minStartYear = await _context.Classes.Where(c => c.StartYear > 0).MinAsync(c => (int?)c.StartYear) ?? 2023;
            var maxStartYear = await _context.Classes.Where(c => c.StartYear > 0).MaxAsync(c => (int?)c.StartYear) ?? 2025;

            var years = new List<string>();
            for (int y = maxStartYear; y >= minStartYear; y--)
            {
                years.Add($"{y}-{y + 1}");
            }

            return Ok(years);
        }
    }
}
