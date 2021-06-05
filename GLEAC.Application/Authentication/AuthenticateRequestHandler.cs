using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GLEAC.Services.Contracts.Authentication;
using GLEAC.Services.Contracts.Authentication.Models;
using MediatR;

namespace GLEAC.Application.Authentication
{
    public class AuthenticateRequestHandler : IRequestHandler<AuthenticateRequest, AuthenticateResponse>
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticateRequestHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<AuthenticateResponse> Handle(AuthenticateRequest request, CancellationToken cancellationToken)
        {
            var response =  _authenticationService.Authenticate(new User(request.Username, request.Password));

            return new AuthenticateResponse(response.AccessToken, response.Expires);
        }
    }
}
