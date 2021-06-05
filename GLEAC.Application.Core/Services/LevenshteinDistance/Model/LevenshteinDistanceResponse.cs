using System;
using System.Collections.Generic;
using System.Text;

namespace GLEAC.Application.Core.Services.LevenshteinDistance.Model
{
    public class LevenshteinDistanceResponse
    {
        public string String1 { get; set; }
        public string String2 { get; set; }
        public int Distance { get; set; }
        
        public int[,] ResultMatrix { get; set; }
    }
}
