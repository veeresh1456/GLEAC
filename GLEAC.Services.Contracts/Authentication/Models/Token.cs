using System;
using System.Collections.Generic;
using System.Text;

namespace GLEAC.Services.Contracts.Authentication.Models
{
    public class Token
    {
        public string AccessToken { get; }
        public int Expires { get; }

        public Token(string accessToken, int expires)
        {
            AccessToken = accessToken;
            Expires = expires;
        }
    }
}
