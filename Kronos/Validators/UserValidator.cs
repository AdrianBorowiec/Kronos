using FluentValidation;
using Kronos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kronos.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).Length(5, 50);
        }
    }
}