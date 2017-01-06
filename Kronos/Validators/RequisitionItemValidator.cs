using FluentValidation;
using Kronos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kronos.Validators
{
    public class RequisitionItemValidator : AbstractValidator<RequisitionItem>
    {
        public RequisitionItemValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(x => x.RequisitionType).NotEmpty();
        }
    }
}