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
    public class OverService : IOverService
    {
        public readonly ScoreCardManagement.Common.Repository.Interface.IOverRepository overRepository;
        public IMapper mapper;
        public OverService(ScoreCardManagement.Common.Repository.Interface.IOverRepository _overRepository, IMapper _mapper)
        {
            overRepository = _overRepository;
            mapper = _mapper;
        }
        public async Task CreateOverAsync(Over over)
        {
             try
            {
                //  var vtournament=TournamentRepository.GetTournamentAsync(tournamentId);
                //  if(vtournament.TournamentId>0)
                 //     var vmatch=MatchRepository.GetMatchAsync(matchId);
                // Validate of tournamentId exisits
                // tournamtRepository.gettournametAsync(tournamentId);
                // Validate if matchid exits
              await overRepository.CreateOverAsync(mapper.Map<ScoreCardManagement.Common.Entities.Over>(over));
             //  await matchRepository.CreateMatchAsync(mapper.Map<ScoreCardManagement.Common.Entities.Match>(match));
            }
            catch(System.Exception ex)
            {
             throw new Exception("Over creation  failed ", ex.InnerException);
            } 
        }

      

        public async Task DeleteOverAsync(int overId)
        {
            try
            {
              await overRepository.DeleteOverAsync(overId);
            }
            catch(System.Exception ex)
            {
             throw new Exception("Over not valid", ex.InnerException);
            }  
        }

        public async Task<List<Over>> GetAllOverAsync(OverFilter overFilter)
        {
            List<Over> lstOver = new List<Over>();
            try
            {
                var over = await overRepository.GetAllOverAsync(overFilter);
                foreach (var item in over)
                {
                    lstOver.Add(mapper.Map<ScoreCardManagement.Common.Entities.Over, Over>(item));
                }
                return lstOver;
            }
            catch (System.Exception ex)
            {
                throw new Exception("Over list  not foumd ", ex.InnerException);
            } 
        }

        public async Task<Over> GetOverAsync(int overId)
        {
             try
            {
               var over = await overRepository.GetOverAsync(overId);
               return mapper.Map<ScoreCardManagement.Common.Entities.Over, Over>(over);
            }
            catch(System.Exception ex)
            {
             throw new Exception("Over not found ", ex.InnerException);
            }
        }

        public async Task UpdateOverAsync(Over over)
        {
            try
            {
             await overRepository.UpdateOverAsync(mapper.Map<ScoreCardManagement.Common.Entities.Over>(over));
            }
            catch(System.Exception ex)
            {
             throw new Exception("Over details not updated", ex.InnerException);
            } 
        }

        
    }
}