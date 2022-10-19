using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace ScoreCardManagement.WebApi.Mapper
{
    public class MappingProfile : Profile
    {
         public MappingProfile() {
         // Add as many of these lines as you need to map your objects
         CreateMap<Contracts.Over, Models.Over>().ReverseMap();
         CreateMap<Models.Over, ScoreCardManagement.Common.Entities.Over>().ReverseMap();

         CreateMap<Contracts.Player, Models.Player>().ReverseMap();
         CreateMap<Models.Player, ScoreCardManagement.Common.Entities.Player>().ReverseMap();

         CreateMap<Contracts.Team, Models.Team>().ReverseMap();
         CreateMap<Models.Team, ScoreCardManagement.Common.Entities.Team>().ReverseMap();
         
         CreateMap<Contracts.Tournament, Models.Tournament>().ReverseMap();
         CreateMap<Models.Tournament, ScoreCardManagement.Common.Entities.Tournament>().ReverseMap();

         CreateMap<Contracts.Match, Models.Match>().ReverseMap();
         CreateMap<Models.Match, ScoreCardManagement.Common.Entities.Match>().ReverseMap();

       
     }
    }
}