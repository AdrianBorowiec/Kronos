using Kronos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Kronos.Configurations
{
    public class ReservationConfiguration : EntityTypeConfiguration<Reservation>
    {
        public ReservationConfiguration()
        {
            ToTable("Reseravtions");

            Property(x => x.Id).IsRequired();
            Property(x => x.ClientName).IsRequired();
            Property(x => x.StartDate).IsRequired();
            Property(x => x.EndDate).IsRequired();
        }
    }
}