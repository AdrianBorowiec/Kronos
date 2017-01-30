using Kronos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kronos.ViewModels
{
    public class OverviewDetailsViewModel
    {
        /// <summary>
        /// Podglądany stół
        /// </summary>
        public Table Table { get; set; }

        /// <summary>
        /// Powiązane rezerwacje
        /// </summary>
        public IEnumerable<Reservation> Reservations { get; set; }

        /// <summary>
        /// Aktualna rezerwacja
        /// </summary>
        public Reservation CurrentReservation { get; set; }

        public OverviewDetailsViewModel()
        {
        }
    }
}