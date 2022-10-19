using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCardManagement.Common.Entities
{
    public class Player
    {
        public int PlayerId {get; set;}
        public string PlayerName {get; set;}
        public int TeamId {get; set;}
        public int PlayerAge{get; set;}
        public string PlayerType{get; set;}
        
        [ForeignKey(nameof(TeamId))]
        public virtual Team Team {get;set;}
    }
}