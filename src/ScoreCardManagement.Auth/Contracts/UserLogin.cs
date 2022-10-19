using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCardManagement.Auth.Contracts
{
    public class UserLogin
    {
        public int UserId {get; set;}
        public string Username { get; set;}=string.Empty;
        public string Password { get; set;}=string.Empty;
    }
}