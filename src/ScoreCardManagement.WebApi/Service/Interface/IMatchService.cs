using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScoreCardManagement.Common.Filters;
using ScoreCardManagement.WebApi.Models;

namespace ScoreCardManagement.WebApi.Service.Interface
{
    public interface IMatchService
    {
        Task CreateMatchAsync(Match match);
         Task<Match> GetMatchAsync(int matchId);
         Task UpdateMatchAsync(Match match);
         Task DeleteMatchAsync(int matchId); 
         Task<List<Match>> GetAllMatchAsync(MatchFilter matchFilter); 
    }
}