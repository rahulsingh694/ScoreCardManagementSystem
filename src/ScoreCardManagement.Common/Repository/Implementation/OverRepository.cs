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
    public class OverRepository : IOverRepository
    {
        public readonly PlayerContext  database;
        public OverRepository(PlayerContext  _database)
        {
          database=_database;
        }
        public async Task CreateOverAsync(Over over)
        {
            if (over == null)
                throw new NullReferenceException("Over doesn't exist.");

            database.Overs.Add(over);
            await database.SaveChangesAsync();
        }

        public async Task DeleteOverAsync(int overId)
        {
            if (overId < 0)
                throw new NullReferenceException("Over doesn't exist.");
            var over = await database.Overs.FirstOrDefaultAsync(x => x.OverId == overId);
            if (over != null)
            {
                database.Overs.Remove(over);
                await database.SaveChangesAsync();
            }
        }

        public async Task<List<Over>> GetAllOverAsync(OverFilter overFilter)
        {
            IQueryable<Over> over = database.Overs;
            if (overFilter != null)
                over = ApplyOverFilter(overFilter);
            var overList = await over.ToListAsync();
            return overList;
        }

        public async Task<Over> GetOverAsync(int overId)
        {
             if (overId < 0)
                throw new NullReferenceException("Over doesn't exist.");
            var over = await database.Overs.FindAsync(overId);
            return over;
        }

        public async Task UpdateOverAsync(Over over)
        {
             if (over == null)
                throw new NullReferenceException("Over doesn't exist");

            var overDb = await database.Overs.FindAsync(over.OverId);

            if (overDb == null)
                throw new NullReferenceException("Over is not found from Db");

            overDb.OverNumber = over.OverNumber;
            overDb.MatchId = over.MatchId;
            overDb.Inning = over.Inning;
            overDb.Run = over.Run;
            overDb.Wicket = over.Wicket;
            database.Overs.Update(overDb);
            await database.SaveChangesAsync();
        }

        private IQueryable<Over> ApplyOverFilter(OverFilter filter)
        {
            IQueryable<Over> over = database.Overs;
            if (filter != null)
            {
               if (filter.OverNumber != null)
                   over = over.Where(c => c.OverNumber == filter.OverNumber);
            }
            return over;
        }
    }
}