using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace GLEAC.Application.LevenshteinDistance
{
    public class GetLevenshteinDistanceRequest : IRequest<GetLevenshteinDistanceResponse>
    {
        public string String1 { get; set; }
        public string String2 { get; set; }

        public string GetCacheKey()
        {
            return (String1 + "-$-" + String2).ToUpper();
        }
    }
}
