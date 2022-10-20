using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCardManagement.Auth.Routes
{
    public class ApiRoutes
    {
        public const string Base="/api";
        public static class User
        {
            public const string user = Base + "/user";
            public const string allUser = Base + "/user/list";
        }
        
        public static class Auth
        {
            public const string Login = Base + "/login";
            public const string ValidateToken = Base + "/validate";
        }
    }
}