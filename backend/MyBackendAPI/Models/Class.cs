using System.Collections.Generic;

namespace MyBackendAPI.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Grade { get; set; }
        public bool IsGradeLocked { get; set; } = false;
        
        public int StartYear { get; set; }
        public string Cohort { get; set; } = string.Empty;

        public int? HomeroomTeacherId { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("HomeroomTeacherId")]
        public User? HomeroomTeacher { get; set; }

        public ICollection<User> Students { get; set; } = new List<User>();
        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
