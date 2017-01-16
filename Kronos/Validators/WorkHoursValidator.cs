using FluentValidation;
using Kronos.Infrastructure;
using Kronos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kronos.Validators
{
    public class WorkHoursValidator : AbstractValidator<WorkHours>
    {
        public WorkHoursValidator()
        {
            RuleFor(x => x.Employee).NotEmpty();
            RuleFor(x => x.StartDate).NotEmpty();
            RuleFor(x => x.EndDate).NotEmpty().GreaterThan(x => x.StartDate);
        }
    }
}