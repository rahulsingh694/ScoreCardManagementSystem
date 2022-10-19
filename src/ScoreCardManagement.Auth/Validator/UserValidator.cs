using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ScoreCardManagement.Auth.Contracts;

namespace ScoreCardManagement.Auth.Validator
{
    public class UserValidator : AbstractValidator<UserD>
    {
        public UserValidator()
        {
        RuleFor(x => x.Username).NotEmpty();
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.ConfirmPassword).NotEmpty().Equal(x => x.Password); 
        }
        
    }
}