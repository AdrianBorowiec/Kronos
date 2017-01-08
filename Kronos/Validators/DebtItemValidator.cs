using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Kronos.Models;
using Kronos.Infrastructure;
using Kronos.DAL;

namespace Kronos.Validators
{
    public class DebtItemValidator : AbstractValidator<DebtItem>
    {
        private IEnumerable<DebtItem> _debtItems;
        private Db db = new Db();

        public DebtItemValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.Value).NotEmpty().GreaterThanOrEqualTo(0.01);
            RuleFor(x => x.Date).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty().GreaterThanOrEqualTo(1);
        }

        public DebtItemValidator(int? debtId)
        {
            _debtItems = db.DebtItems.Where(x => x.Debt.Id == debtId);

            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.Value).NotEmpty().GreaterThanOrEqualTo(0.01);
            RuleFor(x => x.Date).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(x => x.ProductName).SetValidator(new UniqueValidator<DebtItem>(_debtItems))
                .WithMessage("Produkt \"{PropertyValue}\" znajduje się już na liście.");
        }
    }
}