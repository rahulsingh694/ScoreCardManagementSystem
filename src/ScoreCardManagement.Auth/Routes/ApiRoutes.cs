using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCardManagement.Auth.Routes
{
    public class ApiRoutes
    {
        public const string Base = "user";
        public const string Register = Base + "register";
        public const string Login = Base + "login";  
        public const string User =Base; 
       public const string allUser = Base + "list";

    }
}