using System;
using System.Collections.Generic;

namespace MyBackendAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string? StudentId { get; set; }
        public int? ClassId { get; set; }
        public Class? Class { get; set; }
        public string? AvatarUrl { get; set; }
        public DateTime? DateOfBirth { get; set; }
        
        public int? ChildId { get; set; }
        public User? Child { get; set; }

        public string? ResetPasswordOtp { get; set; }
        public DateTime? ResetPasswordOtpExpiry { get; set; }

        public string? SubjectGroup { get; set; } // "Bắt buộc", "Tự nhiên", "Xã hội"

        // Navigation property for Roles
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
        public ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
        
        public ICollection<Club> ClubsLed { get; set; } = new List<Club>();
        public ICollection<ClubMember> ClubMemberships { get; set; } = new List<ClubMember>();

        public DateTime? LastReadNotificationTime { get; set; }
    }
}
