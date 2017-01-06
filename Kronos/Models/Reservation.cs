using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kronos.Models
{
    /// <summary>
    /// Rezerwacja.
    /// </summary>
    public class Reservation
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        [Display(Name = "Identyfikator")]
        public int? Id { get; set; }

        /// <summary>
        /// Nazwisko rezerwującego.
        /// </summary>
        [Display(Name = "Nazwisko rezerwującego")]
        public string Engaging { get; set; }

        /// <summary>
        /// Początek rezerwacji.
        /// </summary>
        [Display(Name = "Początek")]
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// Koniec rezerwacji.
        /// </summary>
        [Display(Name = "Koniec")]
        public DateTime? ToDate { get; set; }

        /// <summary>
        /// Pracownik składający rezerwację.
        /// </summary>
        [Display(Name = "Pracownik składający rezerwację")]
        public virtual Employee Employee { get; set; }

        /// <summary>
        /// Rezerwowany stół.
        /// </summary>
        [Display(Name = "Rezerwowany stół")]
        public virtual Table Table { get; set; }
    }
}