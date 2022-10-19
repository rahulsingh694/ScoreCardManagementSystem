using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScoreCardManagement.Common.Entities;
using ScoreCardManagement.Common.Filters;

namespace ScoreCardManagement.Common.Repository.Interface
{
    public interface IPlayerRepository
    {
       Task CreatePlayerAsync(Player player);
        Task<Player> GetPlayerAsync(int playerId);
        Task UpdatePlayerAsync(Player player);
        Task DeletePlayerAsync(int playerId);
        Task<List<Player>> GetAllPlayerAsync(PlayerFilter playerFilter);
    }
}