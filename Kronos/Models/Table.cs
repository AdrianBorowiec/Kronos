using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Identyfikator")]
        public int? Id { get; set; }

        /// <summary>
        /// Numer stołu.
        /// </summary>
        [Display(Name = "Numer stołu")]
        public int? TableNumber { get; set; }

        /// <summary>
        /// Czy stół aktualnie jest dostępny?
        /// </summary>
        [Display(Name = "Czy stół aktualnie jest dostępny?")]
        public bool? IsAvailable { get; set; }
    }
}