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
    /// Utarg
    /// </summary>
    [Validator(typeof(EarningValidator))]
    public class Earning
    {
        /// <summary>
        /// Identyfikator
        /// </summary>
        [Display(Name = "Identyfikator")]
        public int? Id { get; set; }

        /// <summary>
        /// Data
        /// </summary>
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Kwota zapłacona kartą
        /// </summary>
        [Display(Name = "Kwota zapłacona kartą")]
        public decimal? ByCart { get; set; }

        /// <summary>
        /// Kwota zapłacona gotówką
        /// </summary>
        [Display(Name = "Kwota zapłacona gotówką")]
        public decimal? ByCash { get; set; }

        /// <summary>
        /// Suma
        /// </summary>
        [Display(Name = "Suma")]
        public decimal? Sum { get; set; }
    }
}