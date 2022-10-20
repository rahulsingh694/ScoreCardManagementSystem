using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace ScoreCardManagement.Auth.Helper
{
    public class HelperMethod
    {
     public static string GenerateToken(string secret)
     {

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secret));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return $"Token : {jwt} ";
     }

      public static bool ValidateToken(string token, string secret)
      {
         var tokenHandler = new JwtSecurityTokenHandler();
         var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secret));
         tokenHandler.ValidateToken(token, new TokenValidationParameters
         {
             ValidateIssuerSigningKey = true,
             IssuerSigningKey = key,
             ValidateIssuer = false,
             ValidateAudience = false
         }, out SecurityToken validatedToken);
         var jwtToken = (JwtSecurityToken)validatedToken;
        
         return true;
      }

    public static async Task<string> PasswordHasher(string password)
    {
        return await Task.Run(() => BCrypt.Net.BCrypt.HashPassword(password, 12));
    }

    public static bool VerifyPassword(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
    }
}