using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCardManagement.WebApi.Contracts
{
    public class Player
    {
        public int PlayerId {get; set;}
        public string PlayerName {get; set;}
        public int TeamId {get; set;}
        public int PlayerAge{get; set;}
        public string PlayerType{get; set;}
    }
}