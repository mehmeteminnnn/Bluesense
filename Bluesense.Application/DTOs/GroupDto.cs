namespace Bluesense.Application.DTOs
{
    public class GroupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsPrivate { get; set; }
        public Guid OwnerId { get; set; }
    }
}