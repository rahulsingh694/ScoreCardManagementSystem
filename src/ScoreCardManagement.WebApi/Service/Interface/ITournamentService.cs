using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScoreCardManagement.Common.Filters;
using ScoreCardManagement.WebApi.Models;

namespace ScoreCardManagement.WebApi.Service.Interface
{
    public interface ITournamentService
    {
         Task CreateTournamentAsync(Tournament tournament);
         Task<Tournament> GetTournamentAsync(int tournamentId);
         Task UpdateTournamentAsync(Tournament tournament);
         Task DeleteTournamentAsync(int tournamentId); 
         Task<List<Tournament>> GetAllTournamentAsync(TournamentFilter tournamentFilter);
    }
}