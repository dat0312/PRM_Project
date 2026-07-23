using System;
using System.Collections.Generic;

namespace MyBackendAPI.DTOs
{
    public class DaySlotDto
    {
        public int DayOfWeek { get; set; } // 0 = Sunday, 1 = Monday...
        public int Slot { get; set; }
        public int RoomId { get; set; }
    }

    public class BulkScheduleRequestDto
    {
        public DateTime StartDate { get; set; }
        public int TotalSessions { get; set; }
        public string SubjectCode { get; set; } = string.Empty;
        public int ClassId { get; set; }
        public int TeacherId { get; set; }
        
        public List<DaySlotDto> DaySlots { get; set; } = new List<DaySlotDto>();
    }
}
