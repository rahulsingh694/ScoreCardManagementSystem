using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScoreCardManagement.Auth.Contracts;
using ScoreCardManagement.Auth.Service.Interface;
using AutoMapper;
using ScoreCardManagement.Common.Filters;
using ScoreCardManagement.Common.Entities;

namespace ScoreCardManagement.Auth.Service.Implementation
{
    public class UserService :IUserService
    {
        public readonly ScoreCardManagement.Common.Repository.Interface.IUserRepository userRepository;
      //  public IMapper mapper;
        public UserService(ScoreCardManagement.Common.Repository.Interface.IUserRepository _userRepository)
        {
            userRepository = _userRepository;
          //  mapper = _mapper;
        }

        public async Task RegisterUserAsync(UserD user)
        {
            try
            {
              var userFromRepository=await userRepository.GetUserAsync(user.Id);
              if(userFromRepository != null)
              {
                throw new Exception("User already exist");
              }
              var nuser= new Common.Entities.User
              {
                UserId=user.Id,
                Username=user.Username,
                UserHashPassword=Helper.HelperMethod.PasswordHasher(user.Password).Result
              };
              await userRepository.RegisterUserAsync(nuser);
            }
            catch(System.Exception ex)
            {
             throw new Exception("User creation  failed ", ex.InnerException);
            } 
        }

        public async Task DeleteUserAsync(int userId)
        {
           // var user=await userRepository.GetUserAsync(userId);
            try
            {
              await userRepository.DeleteUserAsync(userId);
            }
            catch(System.Exception ex)
            {
             throw new Exception("User not valid", ex.InnerException);
            } 
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            
            try
            {
                return  await userRepository.GetAllUserAsync();
            }
            catch (System.Exception ex)
            {
                throw new Exception("User list  not foumd ", ex.InnerException);
            }  
        }

        public async Task<User> GetUserAsync(int userId)
        {
            try
            {
               var user = await userRepository.GetUserAsync(userId);
            
              return user;
             
            }
            catch(System.Exception ex)
            {
             throw new Exception("User not found ", ex.InnerException);
            } 
        }

        public async Task UpdateUserAsync(User user)
        {
            try
            {
             await userRepository.UpdateUserAsync(user);
            }
            catch(System.Exception ex)
            {
             throw new Exception("User details not updated", ex.InnerException);
            } 
        }

        Task<UserD> IUserService.GetUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(UserD user)
        {
            throw new NotImplementedException();
        }

        Task<List<UserD>> IUserService.GetAllUserAsync()
        {
            throw new NotImplementedException();
        }

        // Task<UserD> IUserService.GetUserAsync(int userId)
        // {
        //     throw new NotImplementedException();
        // }

        // Task<List<UserD>> IUserService.GetAllUserAsync()
        // {
        //     throw new NotImplementedException();
        // }

        // public Task UpdateUserAsync(UserD user)
        // {
        //     throw new NotImplementedException();
        // }
    }
}