using FluentValidation;
using Kronos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kronos.Validators
{
    public class EarningValidator : AbstractValidator<Earning>
    {
        public EarningValidator()
        {
            RuleFor(x => x.Date).NotEmpty();
            RuleFor(x => x.ByCart).NotEmpty();
            RuleFor(x => x.ByCash).NotEmpty();
        }
    }
}