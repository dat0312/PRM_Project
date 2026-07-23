using System;

namespace MyBackendAPI.Models
{
    public class ScheduleRequest
    {
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public int TeacherId { get; set; }
        public string RequestType { get; set; } = string.Empty; // "Leave", "Makeup"
        public string Reason { get; set; } = string.Empty;
        public DateTime RequestedDate { get; set; }
        public string Status { get; set; } = "Pending"; // "Pending", "Approved", "Rejected"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? MakeUpDate { get; set; }
        public int? MakeUpSlot { get; set; }

        public Schedule? Schedule { get; set; }
        public User? Teacher { get; set; }
    }
}
