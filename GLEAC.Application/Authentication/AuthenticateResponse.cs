using System;
using System.Collections.Generic;
using System.Text;

namespace GLEAC.Application.Authentication
{
    public class AuthenticateResponse
    {
        public string AccessToken { get; set; }
        public int Expires { get; set; }

        public AuthenticateResponse(string accessToken, int expires)
        {
            AccessToken = accessToken;
            Expires = expires;
        }
    }
}
