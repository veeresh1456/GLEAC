using System;
using System.Collections.Generic;
using System.Text;
using GLEAC.Services.Contracts.LevenshteinDistance.Model;

namespace GLEAC.Services.Contracts.LevenshteinDistance
{
    public interface ILevenshteinDistanceService
    {
        LevenshteinDistanceResponse CalculateLevenshteinDistance(LevenshteinDistanceRequest levenshteinDistanceRequest);
    }
}
