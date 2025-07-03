namespace Bluesense.Application.DTOs
{
    public class RefreshTokenDto
    {
        public string Token { get; set; } = null!;
        public DateTime ExpiresAt { get; set; }
        public bool IsActive { get; set; }
    }
}