using FluentValidation.Attributes;
using Kronos.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kronos.Models
{
    /// <summary>
    /// Pozycja listy długów.
    /// </summary>
    [Validator(typeof(DebtItemValidator))]
    public class DebtItem
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        [Display(Name = "Identyfikator")]
        public int? Id { get; set; }

        /// <summary>
        /// Nazwa zakupionego produktu.
        /// </summary>
        [Display(Name = "Nazwa zakupionego produktu")]
        public string ProductName { get; set; }

        /// <summary>
        /// Wartość produktu.
        /// </summary>
        [Display(Name = "Wartość produktu")]
        public double? Value { get; set; }

        /// <summary>
        /// Zakupiona ilość.
        /// </summary>
        [Display(Name = "Zakupiona ilość")]
        public int? Quantity { get; set; }

        /// <summary>
        /// Suma wartości zakupionych produktów.
        /// </summary>
        [NotMapped]
        [Display(Name = "Suma")]
        public double? TotalValue { get; set; }

        /// <summary>
        /// Data utworzenia długu.
        /// </summary>
        [Display(Name = "Data utworzenia długu")]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Dług.
        /// </summary>
        public virtual Debt Debt { get; set; }
    }
}