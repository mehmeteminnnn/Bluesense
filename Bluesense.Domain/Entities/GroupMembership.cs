namespace Bluesense.Domain.Entities
{
    public class GroupMembership
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public Guid GroupId { get; set; }
        public Group? Group { get; set; }
        public bool IsApproved { get; set; }
        public DateTime JoinedAt { get; set; }
        public string? InviteToken { get; set; }
    }
}