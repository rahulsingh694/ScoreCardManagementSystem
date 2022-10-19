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
    public class MatchController :ControllerBase
    {
        public readonly IMatchService matchService;
        public IMapper mapper;
        public MatchController(IMatchService _matchService,IMapper _mapper)
        {
          matchService=_matchService;
          mapper=_mapper;
        }

        [HttpPost(ApiRoutes.Match.match)]
        public async Task <IActionResult> CreateMatchAsync([FromBody]Match match)
        {
            
            try
            {
            await matchService.CreateMatchAsync(mapper.Map<Models.Match>(match));
            return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet(ApiRoutes.Match.match)]
        public async Task<ActionResult> GetMatchAsync(int matchId)
        {
        //  throw new Exception("error from player controller");
        try
         {
          var match = await matchService.GetMatchAsync(matchId);
          return Ok(match);
         }
         catch(Exception ex)
         {
          return BadRequest(ex);
         }

        }

        [HttpPut(ApiRoutes.Match.match)]
        public async Task <IActionResult> UpdateMatchAsync([FromBody]Match match)
        {
            try
            {
            await matchService.UpdateMatchAsync(mapper.Map<Models.Match>(match));
             return Ok();
            }
            catch(Exception ex)
            {
               return BadRequest(ex); 
            }
        }

        [HttpDelete(ApiRoutes.Match.match)]
        public async Task <IActionResult> DeleteMatchAsync(int matchId)
        {
            try
            {
            await matchService.DeleteMatchAsync(matchId);
            return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet(ApiRoutes.Match.allMatch)]
        public async Task<ActionResult> GetAllMatchAsync([FromQuery] MatchFilter? matchFilter = null)
        {
            try
              {
                var match =await matchService.GetAllMatchAsync(matchFilter);
                 return Ok(match);
               }

               catch(Exception ex)
               {
                return BadRequest(ex);
               }
        } 
    }
}