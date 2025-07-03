using Bluesense.Application.DTOs;
using Bluesense.Application.Interfaces;

namespace Bluesense.Application.Services
{
    public class AuthService : IAuthService
    {
        public Task<(string accessToken, RefreshTokenDto refreshToken)> LoginAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> RegisterAsync(string userName, string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<(string accessToken, RefreshTokenDto refreshToken)> RefreshTokenAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task LogoutAsync(Guid userId, string refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}