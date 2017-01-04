using System;
using System.Collections.Generic;
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
        public int? Id { get; set; }

        /// <summary>
        /// Nazwisko rezerwującego.
        /// </summary>
        public string Engaging { get; set; }

        /// <summary>
        /// Początek rezerwacji.
        /// </summary>
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// Koniec rezerwacji.
        /// </summary>
        public DateTime? ToDate { get; set; }

        /// <summary>
        /// Pracownik składający rezerwację.
        /// </summary>
        public virtual Employee Employee { get; set; }

        /// <summary>
        /// Rezerwowany stół.
        /// </summary>
        public virtual Table Table { get; set; }
    }
}