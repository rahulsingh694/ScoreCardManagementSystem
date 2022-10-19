using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScoreCardManagement.Common.Entities;
using ScoreCardManagement.Common.Filters;

namespace ScoreCardManagement.Common.Repository.Interface
{
    public interface IMatchRepository
    {
      Task CreateMatchAsync(Match match);
         Task<Match> GetMatchAsync(int matchId);
         Task UpdateMatchAsync(Match match);
         Task DeleteMatchAsync(int matchId); 
         Task<List<Match>> GetAllMatchAsync(MatchFilter matchFilter);   
    }
}