using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBackendAPI.Models
{
    public class Grade
    {
        [Key]
        public int Id { get; set; }

        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public User? Student { get; set; }

        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject? Subject { get; set; }

        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public Class? Class { get; set; }

        public string AcademicYear { get; set; } = "2023-2024";
        public int Semester { get; set; } = 1;

        public double? AttendanceScore { get; set; } // 5%
        public double? OralScore1 { get; set; }      // 5%
        public double? OralScore2 { get; set; }      // 5%
        public double? FifteenMinScore1 { get; set; } // 10%
        public double? FifteenMinScore2 { get; set; } // 10%
        public double? MidtermScore { get; set; }    // 30%
        public double? FinalScore { get; set; }      // 35%
    }
}
