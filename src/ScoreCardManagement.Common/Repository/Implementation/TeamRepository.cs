using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScoreCardManagement.Common.Data;
using ScoreCardManagement.Common.Entities;
using ScoreCardManagement.Common.Filters;
using ScoreCardManagement.Common.Repository.Interface;

namespace ScoreCardManagement.Common.Repository.Implementation
{
    public class TeamRepository : ITeamRepository
    {
        public readonly PlayerContext  database;
        public TeamRepository(PlayerContext  _database)
        {
          database=_database;
        }
        public async Task CreateTeamAsync(Team team)
        {
            if (team == null)
                throw new NullReferenceException("Team doesn't exist.");

            database.Teams.Add(team);
            await database.SaveChangesAsync(); 
        }

        public async Task DeleteTeamAsync(int teamId)
        {
            if (teamId < 0)
              throw new NullReferenceException("Team doesn't exist.");
            var team = await database.Teams.FirstOrDefaultAsync(x => x.TeamId == teamId);
            if (team != null)
            {
                database.Teams.Remove(team);
                await database.SaveChangesAsync();
            }
        }

        public async Task<List<Team>> GetAllTeamAsync(TeamFilter teamFilter)
        {
            IQueryable<Team> team = database.Teams;
            if (teamFilter != null)
                team = ApplyTeamFilter(teamFilter);
            var teamList = await team.ToListAsync();
            return teamList;
        }

        public async Task<Team> GetTeamAsync(int teamId)
        {
            if (teamId < 0)
                throw new NullReferenceException("Team doesn't exist.");
            var team = await database.Teams.FindAsync(teamId);
            return team;
        }

        public async Task UpdateTeamAsync(Team team)
        {
            if (team == null)
                throw new NullReferenceException("Team doesn't exist");

            var teamDb = await database.Teams.FindAsync(team.TeamId);

            if (teamDb == null)
                throw new NullReferenceException("Team is not found from Db");

            teamDb.TeamId = team.TeamId;

            database.Teams.Update(teamDb);
            await database.SaveChangesAsync(); 
        }

        private IQueryable<Team> ApplyTeamFilter(TeamFilter filter)
        {
            IQueryable<Team> team = database.Teams;
            if (filter != null)
            {
               if (string.IsNullOrEmpty(filter.TeamName) == false)
                    team = team.Where(c => c.TeamName.Contains(filter.TeamName));
              
            }
            return team;
        }
    }
}