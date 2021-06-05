using System;
using System.Collections.Generic;
using System.Text;
using GLEAC.Common.Configuration;
using GLEAC.Services.Authentication;
using GLEAC.Services.Contracts.Authentication.Models;
using Microsoft.Extensions.Options;
using Xunit;

namespace GLEAC.Services.UnitTests
{
    public class TokenServiceTests
    {
        private readonly TokenService _tokenService;

        public TokenServiceTests()
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

            _tokenService = new TokenService(applicationConfiguration);
        }

        [Fact]
        public void ValidateToken_ShouldThrowExceptionIfTokenIsModified()
        {
            var token = _tokenService.GenerateToken(new User("admin", "admin"));

            token = token.Replace("e", "y");

            Assert.Throws<ArgumentException>(() => _tokenService.ValidateToken(token));
        }

        [Fact]
        public void ValidateToken_ShouldValidateTokenIfNotModified()
        {
            var token = _tokenService.GenerateToken(new User("admin", "admin"));

            var jwtDecodedToken = _tokenService.ValidateToken(token);

            Assert.NotNull(jwtDecodedToken);
        }
    }
}
