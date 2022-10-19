using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScoreCardManagement.Common.Filters;
using ScoreCardManagement.WebApi.Models;

namespace ScoreCardManagement.WebApi.Service.Interface
{
    public interface IPlayerService
    {
        Task CreatePlayerAsync(Player player);
        Task<Player> GetPlayerAsync(int playerId);
        Task UpdatePlayerAsync(Player player);
        Task DeletePlayerAsync(int playerId);
        
        Task<List<Player>> GetAllPlayerAsync(PlayerFilter playerFilter);
    }
}