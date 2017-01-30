using FluentValidation;
using FluentValidation.Results;
using Kronos.DAL;
using Kronos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kronos.Validators
{
    public class ReservationValidator : AbstractValidator<Reservation>
    {
        private Db db = new Db();

        public ReservationValidator()
        {
            RuleFor(x => x.ClientName).NotEmpty();
            RuleFor(x => x.StartDate).NotEmpty();
            RuleFor(x => x.EndDate).NotEmpty().GreaterThan(x => x.StartDate);
            RuleFor(x => x.ReseravtionType).NotEmpty();

            Custom(obj =>
            {
                if (obj.ReseravtionType == ReseravtionType.Stół && db.Reservations.Any(x => x.Table.TableNumber == obj.TableNumber && x.StartDate < obj.EndDate && x.EndDate > obj.StartDate))
                {
                    return new ValidationFailure(string.Empty, "W tym okresie istnieje już rezerwacja na wybrany stół!");
                }

                return null;
            });
        }
    }
}