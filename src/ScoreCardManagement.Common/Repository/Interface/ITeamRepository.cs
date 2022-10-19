using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScoreCardManagement.Common.Entities;
using ScoreCardManagement.Common.Filters;

namespace ScoreCardManagement.Common.Repository.Interface
{
    public interface ITeamRepository
    {
        Task CreateTeamAsync(Team team);
        Task<Team> GetTeamAsync(int teamId);
        Task UpdateTeamAsync(Team team);
        Task DeleteTeamAsync(int teamId);  
        Task<List<Team>> GetAllTeamAsync(TeamFilter teamFilter);
    }
}