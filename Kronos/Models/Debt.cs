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
        /// Data utworzenia długu.
        /// </summary>
        [Display(Name = "Data utworzenia długu")]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Wartość długu.
        /// </summary>
        [Display(Name = "Wartość długu")]
        public int? Amount { get; set; }

        /// <summary>
        /// Pracownik wpisujący dług.
        /// </summary>
        [Display(Name = "Pracownik wpisujący dług")]
        public virtual Employee Employee { get; set; }
    }
}