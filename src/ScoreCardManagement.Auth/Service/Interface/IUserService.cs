using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScoreCardManagement.Auth.Contracts;
using ScoreCardManagement.Common.Filters;

namespace ScoreCardManagement.Auth.Service.Interface
{
    public interface IUserService
    {
        Task RegisterUserAsync(UserD user);
         Task<UserD> GetUserAsync(int userId);
         Task UpdateUserAsync(UserD user);
         Task DeleteUserAsync(int userId); 
         Task<List<UserD>> GetAllUserAsync(); 
    }
}