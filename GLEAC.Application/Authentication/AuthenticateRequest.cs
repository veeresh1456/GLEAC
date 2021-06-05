using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace GLEAC.Application.Authentication
{
    public class AuthenticateRequest : IRequest<AuthenticateResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
