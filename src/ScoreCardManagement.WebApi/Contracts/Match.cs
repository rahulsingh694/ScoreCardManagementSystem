using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCardManagement.WebApi.Contracts
{
    public class Match
    {
        public int MatchId {get; set;}
        public string MatchType {get; set;}
        public int TeamId1 {get; set;}
        public int TeamId2 {get; set;}
        public int TournamentId {get; set;}

    }
}