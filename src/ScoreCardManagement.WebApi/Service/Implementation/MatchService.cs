using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ScoreCardManagement.Common.Filters;
using ScoreCardManagement.WebApi.Models;
using ScoreCardManagement.WebApi.Service.Interface;

namespace ScoreCardManagement.WebApi.Service.Implementation
{
    public class MatchService : IMatchService
    {
        public readonly ScoreCardManagement.Common.Repository.Interface.IMatchRepository matchRepository;
        public IMapper mapper;
        public MatchService(ScoreCardManagement.Common.Repository.Interface.IMatchRepository _matchRepository, IMapper _mapper)
        {
            matchRepository = _matchRepository;
            mapper = _mapper;
        }

        public async Task CreateMatchAsync(Match match)
        {
            try
            {
              await matchRepository.CreateMatchAsync(mapper.Map<ScoreCardManagement.Common.Entities.Match>(match));
            }
            catch(System.Exception ex)
            {
             throw new Exception("Match creation  failed ", ex.InnerException);
            } 
        }

        public async Task DeleteMatchAsync(int matchId)
        {
            try
            {
              await matchRepository.DeleteMatchAsync(matchId);
            }
            catch(System.Exception ex)
            {
             throw new Exception("Match not valid", ex.InnerException);
            } 
        }

        public async Task<List<Match>> GetAllMatchAsync(MatchFilter matchFilter)
        {
            List<Match> lstMatch = new List<Match>();
            try
            {
                var match = await matchRepository.GetAllMatchAsync(matchFilter);
                foreach (var item in match)
                {
                    lstMatch.Add(mapper.Map<ScoreCardManagement.Common.Entities.Match, Match>(item));
                }
                return lstMatch;
            }
            catch (System.Exception ex)
            {
                throw new Exception("Match list  not foumd ", ex.InnerException);
            }  
        }

        public async Task<Match> GetMatchAsync(int matchId)
        {
            try
            {
               var match = await matchRepository.GetMatchAsync(matchId);
            //    var tournament=await tournamentRepository.GetTournamentAsync(match.tournamentId);
            //    var team1=await teamRepository.GetTeamAsync(match.teamId1);
            //    var team2=await teamRepository.GetTeamAsync(match.teamId2);

            //    var q=(from mat in PlayerContext.Match 
            //      join tnt in PlayerContext.Tournament on mat.TournamentId equals tnt.TournamentId 
            //      join tm in PlayerContext.Team on tm.TeamId1 equals mat.TeamId1
            //        orderby mat.matchId
            //    select new { 
            //     mat.MatchID,
            //       tm.TeamName,
            //       tnt.TournamentName,
            //     }).ToList(); 
            //  Match match = mapper.Map<ScoreCardManagement.Common.Entities.Match, Match>(matchEntity);
           //   Match match = mapper.Map<ScoreCardManagement.Common.Entities.Match, Match>(matchEntity);
               // Get all overs details for team 1
             //  Get all overs details for team 2
           //   match.OversTeam2 = await overRepository.GetAllOverAsync(tournament);
           //  Over over1 = mapper.Map<ScoreCardManagement.Common.Entities.Over, Over>(over);
           //  Over over2 = mapper.Map<ScoreCardManagement.Common.Entities.Over, Over>(over);
              return mapper.Map<ScoreCardManagement.Common.Entities.Match, Match>(match);
             // return mapper.Map<ScoreCardManagement.Common.Entities.Match, Match>(match);
            }
            catch(System.Exception ex)
            {
             throw new Exception("Match not found ", ex.InnerException);
            } 
        }

        public async Task UpdateMatchAsync(Match match)
        {
            try
            {
             await matchRepository.UpdateMatchAsync(mapper.Map<ScoreCardManagement.Common.Entities.Match>(match));
            }
            catch(System.Exception ex)
            {
             throw new Exception("Match details not updated", ex.InnerException);
            } 
        }

       
    }
}