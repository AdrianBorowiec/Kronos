using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Kronos.Models;
using Kronos.DAL;
using Kronos.Infrastructure;

namespace Kronos.Validators
{
    public class DebtValidator : AbstractValidator<Debt>
    {
        private IEnumerable<Debt> _debtors;
        private Db db = new Db();

        public DebtValidator()
        {
            _debtors = db.Debts.ToList();

            RuleFor(x => x.Debtor).NotEmpty();
            RuleFor(x => x.Debtor).SetValidator(new UniqueValidator<Debt>(_debtors))
                .WithMessage("Dłużnik \"{PropertyValue}\" znajduje się już na liście.");
        }
    }
}