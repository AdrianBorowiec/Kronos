using System;
using System.Collections.Generic;
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
        public int? Id { get; set; }

        /// <summary>
        /// Dłużnik.
        /// </summary>
        public string Debtor { get; set; }

        /// <summary>
        /// Data utworzenia długu.
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Wartość długu.
        /// </summary>
        public int? Amount { get; set; }

        /// <summary>
        /// Pracownik wpisujący dług.
        /// </summary>
        public virtual Employee Employee { get; set; }
    }
}