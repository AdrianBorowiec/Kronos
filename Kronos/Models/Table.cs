using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kronos.Models
{
    /// <summary>
    /// Stół bilardowy
    /// </summary>
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
    }
}