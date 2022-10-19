using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScoreCardManagement.Common.Filters;
using ScoreCardManagement.WebApi.Models;

namespace ScoreCardManagement.WebApi.Service.Interface
{
    public interface ITeamService
    {
         Task CreateTeamAsync(Team team);
         Task<Team> GetTeamAsync(int teamId);
         Task UpdateTeamAsync(Team team);
         Task DeleteTeamAsync(int teamId); 
         Task<List<Team>> GetAllTeamAsync(TeamFilter teamFilter);
    }
}