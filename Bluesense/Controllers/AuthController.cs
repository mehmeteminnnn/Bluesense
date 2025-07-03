using Microsoft.AspNetCore.Mvc;
using Bluesense.Application.Interfaces;
using Bluesense.Application.DTOs;

namespace Bluesense.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var (accessToken, refreshToken) = await _authService.LoginAsync(request.Email, request.Password);
            return Ok(new { accessToken, refreshToken });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var user = await _authService.RegisterAsync(request.UserName, request.Email, request.Password);
            return Ok(user);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshRequest request)
        {
            var (accessToken, refreshToken) = await _authService.RefreshTokenAsync(request.RefreshToken);
            return Ok(new { accessToken, refreshToken });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
        {
            await _authService.LogoutAsync(request.UserId, request.RefreshToken);
            return NoContent();
        }
    }

    public record LoginRequest(string Email, string Password);
    public record RegisterRequest(string UserName, string Email, string Password);
    public record RefreshRequest(string RefreshToken);
    public record LogoutRequest(Guid UserId, string RefreshToken);
}