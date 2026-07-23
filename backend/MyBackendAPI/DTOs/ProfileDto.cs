namespace MyBackendAPI.DTOs
{
    public class UpdateProfileDto
    {
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? AvatarUrl { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
