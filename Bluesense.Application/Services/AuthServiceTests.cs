using Bluesense.Application.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Bluesense.Application.Services.Tests
{
    public class AuthServiceTests
    {
        [Fact]
        public async Task RegisterAsync_ShouldThrowNotImplementedException()
        {
            // Arrange
            var service = new AuthService();

            // Act & Assert
            await Assert.ThrowsAsync<NotImplementedException>(() => service.RegisterAsync("test", "test@test.com", "123456"));
        }
    }
}