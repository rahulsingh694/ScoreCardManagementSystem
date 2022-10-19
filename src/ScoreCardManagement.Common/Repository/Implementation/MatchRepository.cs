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
    public class MatchRepository : IMatchRepository
    {
        public readonly PlayerContext  database;
        public MatchRepository(PlayerContext  _database)
        {
          database=_database;
        }
        public async Task CreateMatchAsync(Match match)
        {
            if (match == null)
                throw new NullReferenceException("Match doesn't exist.");

            database.Matches.Add(match);
            await database.SaveChangesAsync();
        }

        public async Task DeleteMatchAsync(int matchId)
        {
            if (matchId < 0)
                throw new NullReferenceException("Match doesn't exist.");
            var match = await database.Matches.FirstOrDefaultAsync(x => x.MatchId == matchId);
            if (match != null)
            {
                database.Matches.Remove(match);
                await database.SaveChangesAsync();
            }
        }

        public async Task<List<Match>> GetAllMatchAsync(MatchFilter matchFilter)
        {
            IQueryable<Match> match = database.Matches;
            if (matchFilter != null)
                match = ApplyMatchFilter(matchFilter);
         //   match = match.Include(x => x.Team1).Include(x => x.Team2);
            var matchList = await match.ToListAsync();
            return matchList;
        }

        public async Task<Match> GetMatchAsync(int matchId)
        {
             if (matchId < 0)
                throw new NullReferenceException("Match doesn't exist.");
            var match = await database.Matches.FindAsync(matchId);
           // match.Include(c=>c.Team);
            return match;
        }

        public async Task UpdateMatchAsync(Match match)
        {
             if (match == null)
                throw new NullReferenceException("Match doesn't exist");

            var matchDb = await database.Matches.FindAsync(match.MatchId);

            if (matchDb == null)
                throw new NullReferenceException("Match is not found from Db");

            matchDb.MatchId = match.MatchId;
            matchDb.MatchType = match.MatchType;
            matchDb.TeamId1 = match.TeamId1;
            matchDb.TeamId2 = match.TeamId2;
            matchDb.TournamentId = match.TournamentId;
            database.Matches.Update(matchDb);
            await database.SaveChangesAsync();
        }

        private IQueryable<Match> ApplyMatchFilter(MatchFilter filter)
        {
            IQueryable<Match> match = database.Matches;
            if (filter != null)
            {
               if (filter.MatchId != null)
                   match = match.Where(c => c.MatchId == filter.MatchId);
            }
            return match;
        }
    }
}