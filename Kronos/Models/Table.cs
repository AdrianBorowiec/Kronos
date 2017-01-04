using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kronos.Models
{
    /// <summary>
    /// Stół bilardowy.
    /// </summary>
    public class Table
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Numer stołu.
        /// </summary>
        public int? TableNumber { get; set; }

        /// <summary>
        /// Czy stół aktualnie jest dostępny?
        /// </summary>
        public bool? IsAvailable { get; set; }
    }
}