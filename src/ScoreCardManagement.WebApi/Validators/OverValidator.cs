using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ScoreCardManagement.WebApi.Contracts;

namespace ScoreCardManagement.WebApi.Validators
{
    public class OverValidator : AbstractValidator<Over>
    {
        public OverValidator()
        {
            RuleFor(c=>c.OverId).NotEmpty();
        }
    }
}