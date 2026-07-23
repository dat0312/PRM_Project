using System;

namespace MyBackendAPI.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Slot { get; set; }
        public int RoomId { get; set; }
        public string SubjectCode { get; set; } = string.Empty;
        public int ClassId { get; set; }
        public int ClassSize { get; set; } = 30;
        public int TeacherId { get; set; }
        public string Status { get; set; } = "FUTURE"; // PRESENT, FUTURE

        public Class? Class { get; set; }
        public Room? Room { get; set; }
        public User? Teacher { get; set; }
    }
}
