using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCardManagement.WebApi.Routes
{
    public static class ApiRoutes
    {
        public const string Base="/api";
        public static class Player
        {
          public const string player = Base + "/player";
          public const string allPlayer = Base + "/player/list";

        }
      
        public static class Team
        {
          public const string team = Base + "/team";

          public const string allTeam = Base + "/team/list";

        }

       
        public static class Over
        {
         // public const string OverBase = Base + "/tournamemnt/{tournamentId}/match/{matchId}";
         public const string over = Base + "/over";
         public const string allOver = Base + "/over/list";
        }
         public static class Tournament
        {
          public const string tournament = Base + "/tournament";
          public const string allTournament = Base + "/tournament/list";
        }

        public static class Match
        {
          public const string match = Base + "/match";
          public const string allMatch = Base + "/match/list";

        }

       
    }
}