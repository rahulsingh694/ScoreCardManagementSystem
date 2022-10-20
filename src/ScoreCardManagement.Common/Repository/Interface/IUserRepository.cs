using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScoreCardManagement.Common.Entities;
using ScoreCardManagement.Common.Filters;

namespace ScoreCardManagement.Common.Repository.Interface
{
    public interface IUserRepository
    {
        Task RegisterUserAsync(User user);
        Task<User> GetUserAsync(int userId);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int userId);
        Task<List<User>> GetAllUserAsync();
        Task<User> GetUserFromDB(string username);
       // Task SaveToDb(User user);

    }
}