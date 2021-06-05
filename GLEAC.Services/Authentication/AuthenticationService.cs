using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GLEAC.Common.Configuration;
using GLEAC.Services.Contracts.Authentication;
using GLEAC.Services.Contracts.Authentication.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GLEAC.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ApplicationConfiguration _applicationConfiguration;
        private readonly ITokenService _tokenService;

        public AuthenticationService(
            IOptions<ApplicationConfiguration> applicationConfiguration, ITokenService tokenService)
        {
            _applicationConfiguration = applicationConfiguration.Value;
            _tokenService = tokenService;
        }

        public Token Authenticate(User user)
        {
            if (!IsValidUser(user))
                throw new AuthenticationException("Invalid User");

            return new Token(_tokenService.GenerateToken(user), _applicationConfiguration.TokenSettings.Expires);
        }

        private bool IsValidUser(User user)
            => user.Username == _applicationConfiguration.UserLoginDetails.Username &&
               user.Password == _applicationConfiguration.UserLoginDetails.Password;
    }
}
