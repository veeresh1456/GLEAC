using System;
using System.Collections.Generic;
using System.Text;

namespace GLEAC.Services.Contracts.LevenshteinDistance.Model
{
    public class LevenshteinDistanceRequest
    {
        public string String1 { get; set; }
        public string String2 { get; set; }

        public LevenshteinDistanceRequest(string string1, string string2)
        {
            String1 = string1;
            String2 = string2;
        }
    }
}
