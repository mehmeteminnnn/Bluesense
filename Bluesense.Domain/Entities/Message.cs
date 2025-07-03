namespace Bluesense.Domain.Entities
{
    public class Message
    {
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }
        public Group? Group { get; set; }
        public Guid SenderId { get; set; }
        public User? Sender { get; set; }
        public string Content { get; set; } = null!;
        public string? FileUrl { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? EditedAt { get; set; }
    }
}