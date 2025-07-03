namespace Bluesense.Domain.Entities
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsPrivate { get; set; }
        public Guid OwnerId { get; set; }
        public User? Owner { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<GroupMembership>? Members { get; set; }
        public ICollection<Message>? Messages { get; set; }
    }
}