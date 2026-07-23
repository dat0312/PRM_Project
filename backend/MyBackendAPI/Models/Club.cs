using System;
using System.Collections.Generic;

namespace MyBackendAPI.Models
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty; // e.g. MC, BC, IT
        public string Type { get; set; } = string.Empty; // Nghệ thuật & Văn hóa, Thể thao, Học thuật
        public string Status { get; set; } = "HOẠT ĐỘNG"; // HOẠT ĐỘNG, TẠM NGỪNG
        public string Description { get; set; } = string.Empty;
        
        public int? PresidentId { get; set; } // FK to User
        public User? President { get; set; }
        
        public ICollection<ClubMember> Members { get; set; } = new List<ClubMember>();
    }
}
