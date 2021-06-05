using System;
using System.Collections.Generic;
using System.Text;
using GLEAC.Common.Configuration;
using GLEAC.Services.Contracts.LevenshteinDistance;
using GLEAC.Services.Contracts.LevenshteinDistance.Model;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace GLEAC.Services.LevenshteinDistance
{
    public class LevenshteinDistanceService : ILevenshteinDistanceService
    {
        public LevenshteinDistanceResponse CalculateLevenshteinDistance(LevenshteinDistanceRequest levenshteinDistanceRequest)
        {
            if (levenshteinDistanceRequest.String1 == null || levenshteinDistanceRequest.String2 == null)
                throw new ArgumentNullException();

            levenshteinDistanceRequest.String1 = levenshteinDistanceRequest.String1.ToUpper();
            levenshteinDistanceRequest.String2 = levenshteinDistanceRequest.String2.ToUpper();

            var string1Length = levenshteinDistanceRequest.String1.Length;
            var string2Length = levenshteinDistanceRequest.String2.Length;

            var dp = new int[string1Length + 1, string2Length + 1];

            for (var i = 0; i <= string1Length; i++)
            {
                for (var j = 0; j <= string2Length; j++)
                {
                    if (i == 0)
                        dp[i, j] = j;

                    else if (j == 0)
                        dp[i, j] = i;

                    else if (levenshteinDistanceRequest.String1[i - 1] == levenshteinDistanceRequest.String2[j - 1])
                        dp[i, j] = dp[i - 1, j - 1];

                    else
                        dp[i, j] = 1
                                   + Math.Min(Math.Min(dp[i, j - 1],
                                       dp[i - 1, j]), dp[i - 1, j - 1]);
                }
            }

            return new LevenshteinDistanceResponse(levenshteinDistanceRequest.String1,
                levenshteinDistanceRequest.String2, dp[string1Length, string2Length], dp);
        }
    }
}
