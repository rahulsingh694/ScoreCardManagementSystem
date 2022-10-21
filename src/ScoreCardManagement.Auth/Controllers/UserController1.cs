using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScoreCardManagement.Auth.Contracts;
using ScoreCardManagement.Auth.Routes;
using ScoreCardManagement.Auth.Service.Interface;
using ScoreCardManagement.Common.Filters;

namespace ScoreCardManagement.Auth.Controllers
{
   // [Authorize]
    [ApiController]
    public class UserController1 :ControllerBase
    {
        private readonly IUserService userService;
         //public IMapper mapper;
        public UserController1(IUserService _userService)
        {
             userService = _userService;
            // mapper=_mapper;
        }

        [HttpPost(Routes.ApiRoutes.User.user)]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserD request)
        {
            try
            {
                await userService.RegisterUserAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
         
        [HttpGet(Routes.ApiRoutes.User.userbyid)]
        public async Task<ActionResult> GetUserAsync([FromRoute] int id)
        {
        try
         {
          var user = await userService.GetUserAsync(id);
          return Ok(user);
         }
         catch(Exception ex)
         {
          return BadRequest(ex);
         }

        }

        [HttpPut(Routes.ApiRoutes.User.user)]
        public async Task <IActionResult> UpdateUserAsync([FromBody]UserD user)
        {
            try
            {
         //   await userService.UpdateUserAsync(user);
             return Ok();
            }
            catch(Exception ex)
            {
               return BadRequest(ex); 
            }
        }

        [HttpDelete(Routes.ApiRoutes.User.user)]
        public async Task <IActionResult> DeleteUserAsync([FromRoute] int userId)
        {
            try
            {
             await userService.DeleteUserAsync(userId);
             return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet(Routes.ApiRoutes.User.allUser)]
        public async Task<ActionResult> GetAllUserAsync([FromQuery] UserFilter? userFilter = null)
        {
            try
              {
                var user =await userService.GetAllUserAsync();
                 return Ok(user);
               }

               catch(Exception ex)
               {
                return BadRequest(ex);
               }
        } 



    }
}