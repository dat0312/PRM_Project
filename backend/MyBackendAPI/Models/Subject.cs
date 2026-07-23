using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBackendAPI.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Code { get; set; } = string.Empty; // e.g., TOAN10
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty; // e.g., Toán học
        
        [Required]
        public int Grade { get; set; } // 10, 11, 12
        
        [Required]
        [MaxLength(50)]
        public string Group { get; set; } = string.Empty; // "Tự nhiên", "Xã hội", "Bắt buộc"

        public ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
    }
}
