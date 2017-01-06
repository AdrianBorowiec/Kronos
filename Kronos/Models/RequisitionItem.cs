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
    /// Zapotrzebowanie.
    /// </summary>
    [Validator(typeof(RequisitionItemValidator))]
    public class RequisitionItem
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        [Display(Name = "Identyfikator")]
        public int? Id { get; set; }

        /// <summary>
        /// Nazwa produktu.
        /// </summary>
        [Display(Name = "Nazwa produktu")]
        public string Name { get; set; }

        /// <summary>
        /// Ilość.
        /// </summary>
        [Display(Name = "Ilość")]
        public int? Quantity { get; set; }

        /// <summary>
        /// Data utworzenia zapotrzebowania.
        /// </summary>
        [Display(Name = "Data utworzenia")]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// Typ produktu.
        /// </summary>
        [Display(Name = "Typ produktu")]
        public RequisitionType? RequisitionType { get; set; }
    }

    public enum RequisitionType
    {
        Napoje,
        Alkohol,
        [Display(Name = "Produkty spożywcze")]
        ProduktySpożywcze,
        Inne
    }
}