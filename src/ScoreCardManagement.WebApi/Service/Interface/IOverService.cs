using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScoreCardManagement.Common.Filters;
using ScoreCardManagement.WebApi.Models;

namespace ScoreCardManagement.WebApi.Service.Interface
{
    public interface IOverService
    {
         Task CreateOverAsync(Over over);
         Task<Over> GetOverAsync(int overId);
         Task UpdateOverAsync(Over over);
         Task DeleteOverAsync(int overId); 
         Task<List<Over>> GetAllOverAsync(OverFilter overFilter);
    }
}