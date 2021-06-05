using System;
using System.Collections.Generic;
using System.Text;

namespace GLEAC.Services.Contracts.LevenshteinDistance.Model
{
    public class LevenshteinDistanceResponse
    {
        public string String1 { get; }
        public string String2 { get; }
        public int Distance { get; }

        public int[,] ResultMatrix { get; }

        public LevenshteinDistanceResponse(string string1, string string2, int distance, int[,] resultMatrix)
        {
            String1 = string1;
            String2 = string2;
            Distance = distance;
            ResultMatrix = resultMatrix;
        }
    }
}
