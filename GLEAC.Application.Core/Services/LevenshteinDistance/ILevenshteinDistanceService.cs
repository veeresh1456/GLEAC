using System;
using System.Collections.Generic;
using System.Text;
using GLEAC.Application.Core.Services.LevenshteinDistance.Model;

namespace GLEAC.Application.Core.Services.LevenshteinDistance
{
    public interface ILevenshteinDistanceService
    {
        LevenshteinDistanceResponse CalculateLD(LevenshteinDistanceRequest levenshteinDistanceRequest);
    }
}
