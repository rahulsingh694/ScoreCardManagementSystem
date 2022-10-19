using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCardManagement.WebApi.Models
{
    public class Tournament
    {
       public int TournamentId {get; set;}
       public string TournamentType {get; set;} 
        public ICollection<Match> Match {get; set;}
    }
}