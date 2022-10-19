using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ScoreCardManagement.Common.Filters;
using ScoreCardManagement.WebApi.Contracts;
using ScoreCardManagement.WebApi.Routes;
using ScoreCardManagement.WebApi.Service.Interface;

namespace ScoreCardManagement.WebApi.Controllers
{
    [ApiController]
    public class PlayerController : ControllerBase
    {
        public readonly IPlayerService playerService;
        public IMapper mapper;
        public PlayerController(IPlayerService _playerService,IMapper _mapper)
        {
          playerService=_playerService;
          mapper=_mapper;
        }

        [HttpPost(ApiRoutes.Player.player)]
        public async Task <IActionResult> CreatePlayerAsync([FromBody]Player player)
        {
            
            try
            {
            await playerService.CreatePlayerAsync(mapper.Map<Models.Player>(player));
            return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet(ApiRoutes.Player.player)]
        public async Task<ActionResult> GetPlayerAsync(int playerId)
        {
        //  throw new Exception("error from player controller");
        try
         {
          var player = await playerService.GetPlayerAsync(playerId);
          return Ok(player);
         }
         catch(Exception ex)
         {
          return BadRequest(ex);
         }

        }

        [HttpPut(ApiRoutes.Player.player)]
        public async Task <IActionResult> UpdatePlayerAsync([FromBody]Player player)
        {
            try
            {
            await playerService.UpdatePlayerAsync(mapper.Map<Models.Player>(player));
             return Ok();
            }
            catch(Exception ex)
            {
               return BadRequest(ex); 
            }
        }

        [HttpDelete(ApiRoutes.Player.player)]
        public async Task <IActionResult> DeletePlayerAsync(int playerId)
        {
            try
            {
            await playerService.DeletePlayerAsync(playerId);
            return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet(ApiRoutes.Player.allPlayer)]
        public async Task<ActionResult> GetAllPlayerAsync([FromQuery] PlayerFilter? playerFilter = null)
        {
            try
              {
                var player =await playerService.GetAllPlayerAsync(playerFilter);
                 return Ok(player);
               }

               catch(Exception ex)
               {
                return BadRequest(ex);
               }
        }
    }
}