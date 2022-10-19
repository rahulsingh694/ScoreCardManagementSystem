using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCardManagement.WebApi.Contracts
{
    public class Over
    {
        public int OverId {get;set;}
        public int OverNumber {get;set;}
        public int MatchId {get; set;}
        public string Inning {get; set;}
        public int Run {get; set;}
        public int Wicket {get; set;}   
    }
}