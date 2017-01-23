using Kronos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Kronos.Configurations
{
    public class EarningConfiguration : EntityTypeConfiguration<Earning>
    {
        public EarningConfiguration()
        {
            ToTable("Earnings");

            Property(x => x.Id).IsRequired();
            Property(x => x.Date).IsRequired();
            Property(x => x.ByCart).IsRequired().HasPrecision(2, 2);
            Property(x => x.ByCash).IsRequired().HasPrecision(2, 2);
        }
    }
}