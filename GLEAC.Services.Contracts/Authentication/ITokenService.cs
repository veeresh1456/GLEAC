using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using GLEAC.Services.Contracts.Authentication.Models;

namespace GLEAC.Services.Contracts.Authentication
{
    public interface ITokenService
    {
        JwtSecurityToken ValidateToken(string token);
        string GenerateToken(User user);
    }
}
