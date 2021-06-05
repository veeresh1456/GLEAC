using System;
using System.Collections.Generic;
using System.Text;

namespace GLEAC.Services.Contracts.Authentication.Models
{
    public class User
    {
        public string Username { get; }
        public string Password { get; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
