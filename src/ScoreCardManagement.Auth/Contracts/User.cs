using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCardManagement.Auth.Contracts
{
    public class UserD
    {
        public int Id {get; set;}
        public string Username {get; set;}
        public string Password {get; set;}
        public string ConfirmPassword {get; set;}
    }
}