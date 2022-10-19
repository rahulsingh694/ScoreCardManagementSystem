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
    public class TeamService : ITeamService
    {
        public readonly ScoreCardManagement.Common.Repository.Interface.ITeamRepository teamRepository;
        public IMapper mapper;
        public TeamService(ScoreCardManagement.Common.Repository.Interface.ITeamRepository _teamRepository, IMapper _mapper)
        {
            teamRepository = _teamRepository;
            mapper = _mapper;
        }
        public async Task CreateTeamAsync(Team team)
        {
            try
            {
              await teamRepository.CreateTeamAsync(mapper.Map<ScoreCardManagement.Common.Entities.Team>(team));
            }
            catch(System.Exception ex)
            {
             throw new Exception("Team creation  failed ", ex.InnerException);
            } 
        }

        public async Task DeleteTeamAsync(int teamId)
        {
            try
            {
              await teamRepository.DeleteTeamAsync(teamId);
            }
            catch(System.Exception ex)
            {
             throw new Exception("Team doesn't exist", ex.InnerException);
            } 
        }

        public async Task<List<Team>> GetAllTeamAsync(TeamFilter teamFilter)
        {
            List<Team> lstTeam = new List<Team>();
            try
            {
                var team = await teamRepository.GetAllTeamAsync(teamFilter);
                foreach (var item in team)
                {
                    lstTeam.Add(mapper.Map<ScoreCardManagement.Common.Entities.Team, Team>(item));
                }
                return lstTeam;
            }
            catch (System.Exception ex)
            {
                throw new Exception("Team list  not foumd ", ex.InnerException);
            } 
        }

        public async Task<Team> GetTeamAsync(int teamId)
        {
            try
            {
               var team = await teamRepository.GetTeamAsync(teamId);
               return mapper.Map<ScoreCardManagement.Common.Entities.Team, Team>(team);
            }
            catch(System.Exception ex)
            {
             throw new Exception("team not found ", ex.InnerException);
            } 
        }

        public async Task UpdateTeamAsync(Team team)
        {
              try
            {
             await teamRepository.UpdateTeamAsync(mapper.Map<ScoreCardManagement.Common.Entities.Team>(team));
            }
            catch(System.Exception ex)
            {
             throw new Exception("Team details not updated", ex.InnerException);
            }
        }

      
    }
}