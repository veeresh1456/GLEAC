using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GLEAC.Services.Contracts.Authentication.Models;

namespace GLEAC.Services.Contracts.Authentication
{
    public interface IAuthenticationService
    {
        Token Authenticate(User user);
    }
}
