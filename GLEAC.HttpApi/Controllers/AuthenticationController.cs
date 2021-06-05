using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GLEAC.Application.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GLEAC.HttpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<AuthenticateResponse> Post(AuthenticateRequest authenticateRequest)
        {
            return await _mediator.Send(authenticateRequest);
        }
    }
}
