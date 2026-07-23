namespace MyBackendAPI.DTOs
{
    public class ScheduleDto
    {
        public int Id { get; set; }
        public string DateLabel { get; set; } = string.Empty;
        public string Slot { get; set; } = string.Empty;
        public string StartTime { get; set; } = string.Empty;
        public string EndTime { get; set; } = string.Empty;
        public string Room { get; set; } = string.Empty;
        public string SubjectCode { get; set; } = string.Empty;
        public string SubjectName { get; set; } = string.Empty;
        public int SessionNo { get; set; } = 1;
        public string ClassName { get; set; } = string.Empty;
        public int ClassSize { get; set; } = 30;
        public string Lecturer { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        // Raw fields for editing
        public int RoomId { get; set; }
        public int TeacherId { get; set; }
        public int ClassId { get; set; }
        public System.DateTime Date { get; set; }
        public int RawSlot { get; set; }
    }
}
