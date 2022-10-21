using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScoreCardManagement.Auth.Contracts;
using ScoreCardManagement.Auth.Routes;
using ScoreCardManagement.Auth.Service.Interface;

namespace ScoreCardManagement.Auth.Controllers
{
   // [Authorize]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        private readonly IAuthService authService;

        public AuthController(IAuthService _authService)
        {
            authService = _authService;
        }


        [HttpPost(Routes.ApiRoutes.Auth.Login)]
        public async Task<ActionResult<string>> Login([FromBody] UserLogin request)
        {
            try
            {
            var token = await authService.Login(request);
            return Ok(token);
            }
            catch(Exception ex)
            {
              return BadRequest(ex.Message);
            }
        }
        
        [HttpGet(Routes.ApiRoutes.Auth.ValidateToken)]
        public async Task<IActionResult> ValidateToken()
        {

         try
         {
             var result = await authService.ValidateToken(HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last());
             return Ok(result);
         }
         catch (Exception ex)
         {
             return BadRequest(ex.Message);
         }

        }

    }

 }
