using System;
using System.Collections.Generic;
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
        public int? Id { get; set; }

        /// <summary>
        /// Dzień, którego dotyczy wpisywany utarg.
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Wartość utargu.
        /// </summary>
        public int? TotalAmount { get; set; }

        /// <summary>
        /// Pracownik wypisujący utarg.
        /// </summary>
        public virtual Employee Employee { get; set; }
    }
}