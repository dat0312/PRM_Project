using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBackendAPI.Models
{
    public class AppRequest
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        
        public string Content { get; set; } = string.Empty; // Added content for Gmail-like body

        public string Category { get; set; } = string.Empty; // "CLB", "Lịch học", "Thông báo", "Khác"
        
        public string Status { get; set; } = "Chờ duyệt"; // "Chờ duyệt", "Đã duyệt", "Từ chối", "Đã gửi"
        
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public int SenderId { get; set; }
        [ForeignKey("SenderId")]
        public User? Sender { get; set; }

        // Mảng ID người nhận, cách nhau bằng dấu phẩy, ví dụ: "2,5,10" hoặc "ALL"
        public string ReceiverIds { get; set; } = "ALL";

        // Optional reference to a specific entity, e.g. ClubId
        public int? ReferenceId { get; set; }

        public string DeletedByIds { get; set; } = "";
    }
}
