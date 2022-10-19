using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScoreCardManagement.Common.Entities;
using ScoreCardManagement.Common.Filters;

namespace ScoreCardManagement.Common.Repository.Interface
{
    public interface IOverRepository
    {
        Task CreateOverAsync(Over over);
        Task<Over> GetOverAsync(int overId);
        Task UpdateOverAsync(Over over);
        Task DeleteOverAsync(int overId); 
        Task<List<Over>> GetAllOverAsync(OverFilter overFilter); 
    }
}