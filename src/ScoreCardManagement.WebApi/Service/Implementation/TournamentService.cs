using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ScoreCardManagement.Common.Filters;
using ScoreCardManagement.Common.Repository.Implementation;
using ScoreCardManagement.WebApi.Models;
using ScoreCardManagement.WebApi.Service.Interface;

namespace ScoreCardManagement.WebApi.Service.Implementation
{
    public class TournamentService : ITournamentService
    {
        public readonly ScoreCardManagement.Common.Repository.Interface.ITournamentRepository tournamentRepository;
        public IMapper mapper;
        public TournamentService(ScoreCardManagement.Common.Repository.Interface.ITournamentRepository _tournamentRepository, IMapper _mapper)
        {
            tournamentRepository = _tournamentRepository;
            mapper = _mapper;
        }

        public async Task CreateTournamentAsync(Tournament tournament)
        {
            try
            {
              await tournamentRepository.CreateTournamentAsync(mapper.Map<ScoreCardManagement.Common.Entities.Tournament>(tournament));
              // var match = from obj in Matches
                      //     where obj.Match.matchId==Match.matchId
                        //   select obj;
            }
            catch(System.Exception ex)
            {
             throw new Exception("Tournament creation  failed ", ex.InnerException);
            } 
        }

      

        public async Task DeleteTournamentAsync(int tournamentId)
        {
            try
            {
              await tournamentRepository.DeleteTournamentAsync(tournamentId);
            }
            catch(System.Exception ex)
            {
             throw new Exception("Tournament details not found", ex.InnerException);
            } 
        }

        public async Task<List<Tournament>> GetAllTournamentAsync(TournamentFilter tournamentFilter)
        {
            List<Tournament> lstTournament = new List<Tournament>();
            try
            {
                var tournament = await tournamentRepository.GetAllTournamentAsync(tournamentFilter);
                foreach (var item in tournament)
                {
                    lstTournament.Add(mapper.Map<ScoreCardManagement.Common.Entities.Tournament, Tournament>(item));
                }
                return lstTournament;
            }
            catch (System.Exception ex)
            {
                throw new Exception("Tournament list  not foumd ", ex.InnerException);
            } 
        }

        public async Task<Tournament> GetTournamentAsync(int tournamentId)
        {
            try
            {
               var tournament = await tournamentRepository.GetTournamentAsync(tournamentId);
               return mapper.Map<ScoreCardManagement.Common.Entities.Tournament, Tournament>(tournament);
            }
            catch(System.Exception ex)
            {
             throw new Exception("Tournament details not found ", ex.InnerException);
            }
        }

        public async Task UpdateTournamentAsync(Tournament tournament)
        {
             try
            {
             await tournamentRepository.UpdateTournamentAsync(mapper.Map<ScoreCardManagement.Common.Entities.Tournament>(tournament));
            }
            catch(System.Exception ex)
            {
             throw new Exception("Tournament details not updated", ex.InnerException);
            } 
        }
    }
}