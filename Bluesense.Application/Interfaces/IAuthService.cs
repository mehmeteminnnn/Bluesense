using Bluesense.Application.DTOs;

namespace Bluesense.Application.Interfaces
{
    public interface IAuthService
    {
        Task<(string accessToken, RefreshTokenDto refreshToken)> LoginAsync(string email, string password);
        Task<UserDto> RegisterAsync(string userName, string email, string password);
        Task<(string accessToken, RefreshTokenDto refreshToken)> RefreshTokenAsync(string refreshToken);
        Task LogoutAsync(Guid userId, string refreshToken);
    }
}