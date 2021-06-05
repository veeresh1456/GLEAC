using System;
using System.Collections.Generic;
using System.Text;

namespace GLEAC.Common.Configuration
{
    public class TokenSettings
    {
        public string SecretKey { get; set; }
        public int Expires { get; set; }
    }
}
