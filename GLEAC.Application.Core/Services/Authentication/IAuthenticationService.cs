using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GLEAC.Application.Core.Services.Authentication.Models;

namespace GLEAC.Application.Core.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<Token> AuthenticateAsync(User user);
    }
}
