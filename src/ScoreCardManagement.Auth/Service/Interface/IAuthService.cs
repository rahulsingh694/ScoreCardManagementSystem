using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScoreCardManagement.Auth.Contracts;

namespace ScoreCardManagement.Auth.Service.Interface
{
    public interface IAuthService
    {
      //  Task Register (UserD user); 
        Task<string> Login (UserLogin userLogin); 
      //  Task<bool> UserExists(string username);
    }
}