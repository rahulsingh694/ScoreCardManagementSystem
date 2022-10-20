using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using ScoreCardManagement.Auth.Contracts;
using ScoreCardManagement.Auth.Service.Interface;
using ScoreCardManagement.Common.Repository.Interface;
using ScoreCardManagement.Common.Entities;
namespace ScoreCardManagement.Auth.Service.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository userRepository;
        private readonly IConfiguration configuration;
        public AuthService(IUserRepository _userRepository,IConfiguration _configuration)
        {
             userRepository=_userRepository;
             configuration=_configuration;         
        }

         private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
         {
          using (var hmac = new HMACSHA512())
          {
             passwordSalt = hmac.Key;
             passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
          }
         }

         private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
          using (var hmac = new HMACSHA512(passwordSalt))
         {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
         }
        }
        public async Task<string> Login(UserLogin userLogin)
        {

         try
         {
            
            var userFromRepository = await userRepository.GetUserAsync(userLogin.UserId);
            if (userFromRepository == null)
            {
                throw new Exception("User already exists");
            }
            string password = userRepository.GetUserAsync(userLogin.UserId).Result.UserHashPassword;
            
            var HashPassword = BCrypt.Net.BCrypt.Verify(userLogin.Password, password);

            if (!HashPassword)
                throw new Exception("Invalid Password");
            
            else
            {
                var token = GenerateToken();
                return token;
            }
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

        }
     
        public async Task<bool> ValidateToken(string token)
        {
         try
         {
             var secret = configuration.GetSection("AppSettings:Token").Value;
             var result = Helper.HelperMethod.ValidateToken(token, secret);
             return result;
         }
         catch (Exception ex)
         {
             return false;
         }
         }
        // public async Task Register(Contracts.User user)
        // {
        //    try
        //   {
        //     var userFromRepository = await userRepository.GetUserFromDB(user.Username);
        //     if (userFromRepository != null)
        //     {
        //         throw new Exception("User already exists");
        //     }


        //     var nuser = new Common.Entities.User
        //     {
        //         UserId = user.Id,
        //         Username = user.Username,
        //         UserHashPassword = PasswordHasher(user.Password).Result,   
        //     };
        //     await userRepository.SaveToDb(nuser);
        //  }
        //   catch (Exception ex)
        //   {
        //      Console.WriteLine(ex.Message);
        //   }

        //  }
        
         public async Task<string> PasswordHasher(string password)
         {
          return await Task.Run(() => BCrypt.Net.BCrypt.HashPassword(password, 12));
         }

       

         public string GenerateToken()
         {

           var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
            configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

           var jwt = new JwtSecurityTokenHandler().WriteToken(token);

           return jwt;
         }

       
    }
}