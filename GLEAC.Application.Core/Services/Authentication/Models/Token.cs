using System;
using System.Collections.Generic;
using System.Text;

namespace GLEAC.Application.Core.Services.Authentication.Models
{
    public class Token
    {
        public string AccessToken { get; set; }
        public int Expires { get; set; }
    }
}
