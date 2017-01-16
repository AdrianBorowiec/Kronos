using FluentValidation;
using Kronos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kronos.Validators
{
    public class TableValidator : AbstractValidator<Table>
    {
        public TableValidator()
        {
            RuleFor(x => x.TableNumber).NotEmpty();
            RuleFor(x => x.IsFree).NotEmpty();
        }
    }
}