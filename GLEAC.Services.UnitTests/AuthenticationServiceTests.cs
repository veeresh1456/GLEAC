using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;
using GLEAC.Common.Configuration;
using GLEAC.Services.Authentication;
using GLEAC.Services.Contracts.Authentication;
using GLEAC.Services.Contracts.Authentication.Models;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace GLEAC.Services.UnitTests
{
    public class AuthenticationServiceTests
    {
        private readonly AuthenticationService _authenticationService;
        private readonly Mock<ITokenService> _tokenService;

        public AuthenticationServiceTests()
        {
            var applicationConfiguration = Options.Create(new ApplicationConfiguration()
            {
                UserLoginDetails = new UserLoginDetails()
                {
                    Username = "admin",
                    Password = "admin"
                },
                TokenSettings = new TokenSettings()
                {
                    Expires = 3600,
                    SecretKey = "jRxBiY6YnC2Zm6wfGqWgcdsYb9sYSj70jRxBiY6YnC2Zm6wfGqWgcdsYb9sYSj70"
                }
            });

            _tokenService = new Mock<ITokenService>();

            _authenticationService = new AuthenticationService(applicationConfiguration, _tokenService.Object);
        }

        [Fact]
        public void Authenticate_ShouldCallGenerateTokenWhenValidLoginDetailsSubmitted()
        {
            var user = new User("admin", "admin");

            var token = _authenticationService.Authenticate(user);

            _tokenService.Verify(m => m.GenerateToken(user), Times.Exactly(1));
        }

        [Fact]
        public void Authenticate_ShouldThrowExceptionWhenInvalidValidLoginDetailsSubmitted()
        {
            Assert.Throws<AuthenticationException>(() => _authenticationService.Authenticate(new User("test", "test")));
        }
    }
}
