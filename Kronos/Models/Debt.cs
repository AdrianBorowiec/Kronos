using FluentValidation.Attributes;
using Kronos.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kronos.Models
{
    /// <summary>
    /// Dług.
    /// </summary>
    [Validator(typeof(DebtValidator))]
    public class Debt
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        [Display(Name = "Identyfikator")]
        public int? Id { get; set; }

        /// <summary>
        /// Dłużnik.
        /// </summary>
        [Display(Name = "Dłużnik")]
        public string Debtor { get; set; }

        /// <summary>
        /// Wartość długu.
        /// </summary>
        [Display(Name = "Wartość długu")]
        [DataType(DataType.Currency)]
        public decimal? TotalAmount { get; set; }

        /// <summary>
        /// Pracownik wpisujący dług.
        /// </summary>
        //[Display(Name = "Pracownik wpisujący dług")]
        //public virtual Employee Employee { get; set; }

        /// <summary>
        /// Pozycje listy długów.
        /// </summary>
        public virtual ICollection<DebtItem> DebtItems { get; set; }       
    }
}