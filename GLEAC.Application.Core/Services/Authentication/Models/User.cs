using System;
using System.Collections.Generic;
using System.Text;

namespace GLEAC.Application.Core.Services.Authentication.Models
{
    public class User
    {
        public string UserName { get; }
        public string Password { get; }

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
