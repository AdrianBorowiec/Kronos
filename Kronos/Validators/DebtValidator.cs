using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Kronos.Models;

namespace Kronos.Validators
{
    public class DebtValidator : AbstractValidator<Debt>
    {
        public DebtValidator()
        {
            RuleFor(x => x.Debtor).NotEmpty();
        }
    }
}