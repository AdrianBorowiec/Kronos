using Kronos.DAL;
using Kronos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kronos.ViewModels
{
    public class OverviewViewModel
    {
        /// <summary>
        /// Stoły
        /// </summary>
        public IEnumerable<Table> Tables { get; set; }

        /// <summary>
        /// Rezerwacje
        /// </summary>
        public IEnumerable<Reservation> Reservations { get; set; }

        public OverviewViewModel()
        {
            var db = new Db();

            this.Tables = db.Tables.ToList();
            this.Reservations = db.Reservations.ToList();
        }
    }

    
}