using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScoreCardManagement.Common.Entities;
using ScoreCardManagement.Common.Filters;

namespace ScoreCardManagement.Common.Repository.Interface
{
    public interface ITournamentRepository
    {
        Task CreateTournamentAsync(Tournament tournament);
        Task<Tournament> GetTournamentAsync(int tournamentId);
        Task UpdateTournamentAsync(Tournament tournament);
        Task DeleteTournamentAsync(int tournamentId);  
        Task<List<Tournament>> GetAllTournamentAsync(TournamentFilter tournamentFilter);
    }
}