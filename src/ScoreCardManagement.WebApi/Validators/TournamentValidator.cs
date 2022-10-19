using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using ScoreCardManagement.WebApi.Contracts;
namespace ScoreCardManagement.WebApi.Validators 
{
    public class TournamentValidator :AbstractValidator<Tournament>
    {

        public TournamentValidator()
        {
           RuleFor(c=>c.TournamentType).NotEmpty();
        }
    }
}