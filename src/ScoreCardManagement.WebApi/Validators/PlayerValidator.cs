using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ScoreCardManagement.WebApi.Contracts;

namespace ScoreCardManagement.WebApi.Validators
{
    public class PlayerValidator : AbstractValidator<Player>
    {
        public PlayerValidator()
        {
            RuleFor(c=>c.PlayerName).NotEmpty();
        }
    }
}