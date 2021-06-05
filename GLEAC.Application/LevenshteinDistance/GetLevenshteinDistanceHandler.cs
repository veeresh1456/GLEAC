using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GLEAC.Application.Authentication;
using GLEAC.Common.Configuration;
using GLEAC.Services.Contracts.Authentication.Models;
using GLEAC.Services.Contracts.LevenshteinDistance;
using GLEAC.Services.Contracts.LevenshteinDistance.Model;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace GLEAC.Application.LevenshteinDistance
{
    public class GetLevenshteinDistanceHandler : IRequestHandler<GetLevenshteinDistanceRequest, GetLevenshteinDistanceResponse>
    {
        private readonly ILevenshteinDistanceService _levenshteinDistanceService;
        private readonly IMemoryCache _memoryCache;
        private readonly ApplicationConfiguration _applicationConfiguration;

        public GetLevenshteinDistanceHandler(ILevenshteinDistanceService levenshteinDistanceService,
            IMemoryCache memoryCache, IOptions<ApplicationConfiguration> applicationConfiguration)
        {
            _levenshteinDistanceService = levenshteinDistanceService;
            _memoryCache = memoryCache;
            _applicationConfiguration = applicationConfiguration.Value;
        }

        public async Task<GetLevenshteinDistanceResponse> Handle(GetLevenshteinDistanceRequest request, CancellationToken cancellationToken)
        {
            if (_memoryCache.TryGetValue(request.GetCacheKey(),
                out LevenshteinDistanceResponse levenshteinDistanceResponse))
                return new GetLevenshteinDistanceResponse(levenshteinDistanceResponse);

            levenshteinDistanceResponse = _levenshteinDistanceService.CalculateLevenshteinDistance(
                new LevenshteinDistanceRequest(request.String1, request.String2));

            _memoryCache.Set(request.GetCacheKey(), levenshteinDistanceResponse,
                TimeSpan.FromSeconds(_applicationConfiguration.LevenshteinDistanceCacheExpires));

            return new GetLevenshteinDistanceResponse(levenshteinDistanceResponse);
        }
    }
}
