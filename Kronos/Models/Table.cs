using FluentValidation.Attributes;
using Kronos.DAL;
using Kronos.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kronos.Models
{
    /// <summary>
    /// Stół bilardowy
    /// </summary>
    [Validator(typeof(TableValidator))]
    public class Table
    {
        /// <summary>
        /// Identyfikator
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Numer stolu
        /// </summary>
        public int? TableNumber { get; set; }

        /// <summary>
        /// Czy stół jest dostępny?
        /// </summary>
        [NotMapped]
        public bool IsFree
        {
            get
            {
                return !Reservations.Any(x => x.StartDate <= DateTime.Now && x.EndDate >= DateTime.Now);
            }
        }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}