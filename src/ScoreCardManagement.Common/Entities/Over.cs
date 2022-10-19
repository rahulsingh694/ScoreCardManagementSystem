using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCardManagement.Common.Entities
{
    public class Over
    {
        public int OverId {get;set;}
        public int OverNumber {get;set;}
        public int MatchId {get; set;}
        public string Inning {get; set;}
        public int Run {get; set;}
        public int Wicket {get; set;}

        [ForeignKey(nameof(MatchId))]
        public virtual Match Match {get; set;}
    }
}