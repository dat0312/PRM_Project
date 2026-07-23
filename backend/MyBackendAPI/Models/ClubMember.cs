using System;

namespace MyBackendAPI.Models
{
    public class ClubMember
    {
        public int ClubId { get; set; }
        public Club? Club { get; set; }
        
        public int UserId { get; set; }
        public User? User { get; set; }
        
        public DateTime JoinedDate { get; set; } = DateTime.UtcNow;
    }
}
