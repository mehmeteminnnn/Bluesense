namespace Bluesense.Application.DTOs
{
    public class MessageDto
    {
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }
        public Guid SenderId { get; set; }
        public string Content { get; set; } = null!;
        public string? FileUrl { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? EditedAt { get; set; }
    }
}