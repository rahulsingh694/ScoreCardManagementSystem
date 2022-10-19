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
    public class TeamController : ControllerBase
    {
        public readonly ITeamService teamService;
        public IMapper mapper;
        public TeamController(ITeamService _teamService,IMapper _mapper)
        {
          teamService=_teamService;
          mapper=_mapper;
        }

        [HttpPost(ApiRoutes.Team.team)]
        public async Task <IActionResult> CreateTeamAsync([FromBody]Team team)
        {
            
            try
            {
            await teamService.CreateTeamAsync(mapper.Map<Models.Team>(team));
            return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet(ApiRoutes.Team.team)]
        public async Task<ActionResult> GetTeamAsync(int teamId)
        {
        //  throw new Exception("error from player controller");
        try
         {
          var team = await teamService.GetTeamAsync(teamId);
          return Ok(team);
         }
         catch(Exception ex)
         {
          return BadRequest(ex);
         }

        }

        [HttpPut(ApiRoutes.Team.team)]
        public async Task <IActionResult> UpdateTeamAsync([FromBody]Team team)
        {
            try
            {
            await teamService.UpdateTeamAsync(mapper.Map<Models.Team>(team));
             return Ok();
            }
            catch(Exception ex)
            {
               return BadRequest(ex); 
            }
        }

        [HttpDelete(ApiRoutes.Team.team)]
        public async Task <IActionResult> DeleteTeamAsync(int teamId)
        {
            try
            {
            await teamService.DeleteTeamAsync(teamId);
            return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet(ApiRoutes.Team.allTeam)]
        public async Task<ActionResult> GetAllTeamAsync([FromQuery] TeamFilter? teamFilter = null)
        {
            try
              {
                var team =await teamService.GetAllTeamAsync(teamFilter);
                 return Ok(team);
               }

               catch(Exception ex)
               {
                return BadRequest(ex);
               }
        } 
    }
}