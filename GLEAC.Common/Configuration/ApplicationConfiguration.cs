using System;
using System.Collections.Generic;
using System.Text;

namespace GLEAC.Common.Configuration
{
    public class ApplicationConfiguration
    {
        public UserLoginDetails UserLoginDetails { get; set; }
        public TokenSettings TokenSettings { get; set; }

        public int LevenshteinDistanceCacheExpires { get; set; }
    }
}
