using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCardManagement.Common.Entities
{
    public class Match
    {
        public int MatchId {get; set;}
        public string MatchType {get; set;}
        public int TeamId1 {get; set;}
        public int TeamId2 {get; set;}
        public int TournamentId {get; set;} 

        [ForeignKey(nameof(TournamentId))]
        public virtual Tournament Tournament {get; set;}

        [ForeignKey(nameof(TeamId1))]
        public virtual Team Team1 {get; set;}

        
        [ForeignKey(nameof(TeamId2))]
        public virtual Team Team2 {get; set;}
    }
}