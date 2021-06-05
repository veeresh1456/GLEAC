using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GLEAC.Common.Configuration;
using GLEAC.Services.Contracts.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GLEAC.HttpApi.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ApplicationConfiguration _applicationConfiguration;
        private readonly ITokenService _tokenService;

        public AuthenticationMiddleware(RequestDelegate next,
            IOptions<ApplicationConfiguration> applicationConfiguration, ITokenService tokenService)
        {
            _next = next;
            _applicationConfiguration = applicationConfiguration.Value;
            _tokenService = tokenService;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                await AttachAccountToContext(context, token);

            await _next(context);
        }

        private async Task AttachAccountToContext(HttpContext context, string token)
        {
            try
            {
                var jwtToken = _tokenService.ValidateToken(token);

                var userName = jwtToken.Claims.First(x => x.Type == "Username").Value;

                context.Items["Account"] = userName;
            }
            catch (Exception ex)
            {
                // do nothing if jwt validation fails
                // account is not attached to context so request won't have access to secure routes
            }
        }
    }
}
