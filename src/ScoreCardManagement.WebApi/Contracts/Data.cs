using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCardManagement.WebApi.Contracts
{
    public class Data
    {
         public int MatchId {get; set;}
        public string MatchType {get; set;}
        public int TeamId1 {get; set;}
        public int TeamId2 {get; set;}
        

         public int OverId {get;set;}
        public int OverNumber {get;set;}
        
        public string Inning {get; set;}
        public int Run {get; set;}
        public int Wicket {get; set;} 

         public int PlayerId {get; set;}
        public string PlayerName {get; set;}
        
        public int PlayerAge{get; set;}
        public string PlayerType{get; set;}

         public int TeamId {get; set;}
        public string TeamName {get; set;}

           public int TournamentId {get; set;}
          public string TournamentType {get; set;}  





    }
}