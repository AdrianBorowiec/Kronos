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
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().WithMessage("Pole nie może być puste!");
            RuleFor(x => x.CreateDate).NotEmpty().WithMessage("Pole nie może być puste!");
        }
    }
}