using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Kronos.Models;

namespace Kronos.Validators
{
    public class DebtItemValidator : AbstractValidator<DebtItem>
    {
        public DebtItemValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.Value).NotEmpty().GreaterThanOrEqualTo(0.01);
            RuleFor(x => x.Date).NotEmpty();
        }
    }
}