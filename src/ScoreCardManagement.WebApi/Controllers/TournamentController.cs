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
    public class TournamentController : ControllerBase
    {
        public readonly ITournamentService tournamentService;
        public IMapper mapper;
        public TournamentController(ITournamentService _tournamentService,IMapper _mapper)
        {
          tournamentService=_tournamentService;
          mapper=_mapper;
        }

        [HttpPost(ApiRoutes.Tournament.tournament)]
        public async Task <IActionResult> CreateTournamentAsync([FromBody]Tournament tournament)
        {
            
            try
            {
            await tournamentService.CreateTournamentAsync(mapper.Map<Models.Tournament>(tournament));
            return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet(ApiRoutes.Tournament.tournament)]
        public async Task<ActionResult> GetTournamentAsync(int tournamentId)
        {
        //  throw new Exception("error from player controller");
        try
         {
          var tournament = await tournamentService.GetTournamentAsync(tournamentId);
          return Ok(tournament);
         }
         catch(Exception ex)
         {
          return BadRequest(ex);
         }

        }

        [HttpPut(ApiRoutes.Tournament.tournament)]
        public async Task <IActionResult> UpdateTournamentAsync([FromBody]Tournament tournament)
        {
            try
            {
            await tournamentService.UpdateTournamentAsync(mapper.Map<Models.Tournament>(tournament));
             return Ok();
            }
            catch(Exception ex)
            {
               return BadRequest(ex); 
            }
        }

        [HttpDelete(ApiRoutes.Tournament.tournament)]
        public async Task <IActionResult> DeleteTournamentAsync(int tournamentId)
        {
            try
            {
            await tournamentService.DeleteTournamentAsync(tournamentId);
            return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet(ApiRoutes.Tournament.allTournament)]
        public async Task<ActionResult> GetAllTournamentAsync([FromQuery] TournamentFilter? tournamentFilter = null)
        {
            try
              {
                var tournament =await tournamentService.GetAllTournamentAsync(tournamentFilter);
                 return Ok(tournament);
               }

               catch(Exception ex)
               {
                return BadRequest(ex);
               }
        } 
    }
}