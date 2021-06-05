using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GLEAC.Application.LevenshteinDistance;
using GLEAC.HttpApi.Attributes;
using GLEAC.Services.Contracts.LevenshteinDistance.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GLEAC.HttpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authenticate]
    public class LevenshteinDistanceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LevenshteinDistanceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<GetLevenshteinDistanceResponse> Post(GetLevenshteinDistanceRequest levenshteinDistanceRequest)
        {
            return await _mediator.Send(levenshteinDistanceRequest);
        }
    }
}
