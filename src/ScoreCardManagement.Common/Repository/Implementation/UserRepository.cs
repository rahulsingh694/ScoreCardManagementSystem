using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScoreCardManagement.Common.Data;
using ScoreCardManagement.Common.Entities;
using ScoreCardManagement.Common.Filters;
using ScoreCardManagement.Common.Repository.Interface;
using Microsoft.Extensions.Configuration;

namespace ScoreCardManagement.Common.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        public readonly PlayerContext database;
        private readonly IConfiguration configuration; 
        public UserRepository(PlayerContext _database,IConfiguration _configuration)
        {
            database = _database;
            configuration=_configuration;
        }
        public async Task RegisterUserAsync(User user)
        {
            // if (user == null)
            //     throw new NullReferenceException("User doesn't exist.");

            database.Users.Add(user);
            await database.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            if (userId < 0)
                throw new NullReferenceException("User doesn't exist.");
            var user = await database.Users.FirstOrDefaultAsync(x => x.UserId == userId);
            if (user != null)
            {
                database.Users.Remove(user);
                await database.SaveChangesAsync();
            }
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            IQueryable<User> user = database.Users;
            // if (userFilter != null)
            //     user = ApplyUserFilter(userFilter);
            
            var userList = await user.ToListAsync();
            return userList;
        }

        public async Task<User> GetUserAsync(int userId)
        {
            if (userId < 0)
                throw new NullReferenceException("User doesn't exist.");
            var user = await database.Users.FindAsync(userId);
        
            return user;
        }

        public async Task<User> GetUserFromDB(string username)
        {
            try
            {
                var user = await database.Users.FirstOrDefaultAsync(x => x.Username == username);

                if (user == null)
                    throw new Exception("User not found");
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }

        public async Task SaveToDb(User user)
        {
             await database.Users.AddAsync(user);
             await database.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            if (user == null)
                throw new NullReferenceException("User doesn't exist");

            var userDb = await database.Users.FindAsync(user.UserId);

            if (userDb == null)
                throw new NullReferenceException("User is not found from Db");

            
            
            database.Users.Update(userDb);
            await database.SaveChangesAsync();
        }

        private IQueryable<User> ApplyUserFilter(UserFilter filter)
        {
            IQueryable<User> user = database.Users;
            if (filter != null)
            {
                if (filter.UserId != null)
                    user = user.Where(c => c.UserId == filter.UserId);
            }
            return user;
        }
    }
}