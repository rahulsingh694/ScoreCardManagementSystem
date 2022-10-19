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

    public class TournamentRepository : ITournamentRepository
    {
         public readonly PlayerContext  database;
        public TournamentRepository(PlayerContext  _database)
        {
          database=_database;
        }
        public async Task CreateTournamentAsync(Tournament tournament)
        {
             if (tournament == null)
                throw new NullReferenceException("Tournament doesn't exist.");

            database.Tournaments.Add(tournament);
            await database.SaveChangesAsync(); 
        }

        public async Task DeleteTournamentAsync(int tournamentId)
        {
            if (tournamentId < 0)
              throw new NullReferenceException("Tournament doesn't exist.");
            var tournament = await database.Tournaments.FirstOrDefaultAsync(x => x.TournamentId == tournamentId);
            if (tournament != null)
            {
                database.Tournaments.Remove(tournament);
                await database.SaveChangesAsync();
            }
        }

        public async Task<List<Tournament>> GetAllTournamentAsync(TournamentFilter tournamentFilter)
        {
            IQueryable<Tournament> tournament = database.Tournaments;
            if (tournamentFilter != null)
                tournament = ApplyTournamentFilter(tournamentFilter);
            var tournamentList = await tournament.ToListAsync();
            return tournamentList; 
        }

        public async Task<Tournament> GetTournamentAsync(int tournamentId)
        {
            if (tournamentId < 0)
                throw new NullReferenceException("Tournament doesn't exist.");
            var tournament = await database.Tournaments.FindAsync(tournamentId);
          //  var c =await database.Matches.FindAsync(x=> x.TournamentId.Equals(tournamentId));
         //   var match =await database.Matches.FindAsync(matchId);
            return tournament;
        }

        public async Task UpdateTournamentAsync(Tournament tournament)
        {
           if (tournament == null)
                throw new NullReferenceException("Tournament doesn't exist");

            var tournamentDb = await database.Tournaments.FindAsync(tournament.TournamentId);

            if (tournamentDb == null)
                throw new NullReferenceException("Tournament is not found from Db");

            tournamentDb.TournamentId = tournament.TournamentId;

            database.Tournaments.Update(tournamentDb);
            await database.SaveChangesAsync();  
        }

         private IQueryable<Tournament> ApplyTournamentFilter(TournamentFilter filter)
        {
            IQueryable<Tournament> tournament = database.Tournaments;
            if (filter != null)
            {
               if (string.IsNullOrEmpty(filter.TournamentType) == false)
                    tournament = tournament.Where(c => c.TournamentType.Contains(filter.TournamentType));
              
            }
            return tournament;
        }
    }
}