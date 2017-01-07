using FluentValidation;
using Kronos.DAL;
using Kronos.Infrastructure;
using Kronos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kronos.Validators
{
    public class RequisitionItemValidator : AbstractValidator<RequisitionItem>
    {
        private IEnumerable<RequisitionItem> _requisitionItem;
        private Db db = new Db();

        public RequisitionItemValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(x => x.RequisitionType).NotEmpty();
            RuleFor(x => x.Name).SetValidator(new UniqueValidator<RequisitionItem>(_requisitionItem))
                .WithMessage("Produkt \"{PropertyValue}\" znajduje się już na liście.");
        }
    }
}