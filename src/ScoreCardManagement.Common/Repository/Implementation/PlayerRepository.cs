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
    public class PlayerRepository : IPlayerRepository
    {
        public readonly PlayerContext  database;
        public PlayerRepository(PlayerContext  _database)
        {
          database=_database;
        }
        public async Task CreatePlayerAsync(Player player)
        {
            if (player == null)
                throw new NullReferenceException("Player doesn't exist.");

            database.Players.Add(player);
            await database.SaveChangesAsync();  
        }

        public async Task DeletePlayerAsync(int playerId)
        {
            if (playerId < 0)
                throw new NullReferenceException("Player doesn't exist.");
            var player = await database.Players.FirstOrDefaultAsync(x => x.PlayerId == playerId);
            if (player != null)
            {
                database.Players.Remove(player);
                await database.SaveChangesAsync();
            } 
        }

        public async Task<List<Player>> GetAllPlayerAsync(PlayerFilter playerFilter)
        {
            IQueryable<Player> over = database.Players;
            if (playerFilter != null)
                over = ApplyPlayerFilter(playerFilter);
            var playerList = await over.ToListAsync();
            return playerList;
        }

        public async Task<Player> GetPlayerAsync(int playerId)
        {
            if (playerId < 0)
                throw new NullReferenceException("Player doesn't exist.");
            var player = await database.Players.FindAsync(playerId);
            return player;
        }

        public async Task UpdatePlayerAsync(Player player)
        {
            if (player == null)
                throw new NullReferenceException("Player doesn't exist");

            var playerDb = await database.Players.FindAsync(player.PlayerId);

            if (playerDb == null)
                throw new NullReferenceException("Player is not found from Db");

            playerDb.PlayerName = player.PlayerName;

            database.Players.Update(playerDb);
            await database.SaveChangesAsync(); 
        }

        private IQueryable<Player> ApplyPlayerFilter(PlayerFilter filter)
        {
            IQueryable<Player> player = database.Players;
            if (filter != null)
            {
               if (string.IsNullOrEmpty(filter.PlayerName) == false)
                    player = player.Where(c => c.PlayerName.Contains(filter.PlayerName));
            }
            return player;
        }
    }
}