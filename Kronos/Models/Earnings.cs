using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kronos.Models
{
    /// <summary>
    /// Utarg.
    /// </summary>
    public class Earnings
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        [Display(Name = "Identyfikator")]
        public int? Id { get; set; }

        /// <summary>
        /// Dzień utargu.
        /// </summary>
        [Display(Name = "Dzień utargu.")]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Wartość utargu.
        /// </summary>
        [Display(Name = "Wartość utargu")]
        public int? TotalAmount { get; set; }

        /// <summary>
        /// Pracownik wypisujący utarg.
        /// </summary>
        [Display(Name = "Pracownik wypisujący utarg")]
        public virtual Employee Employee { get; set; }
    }
}