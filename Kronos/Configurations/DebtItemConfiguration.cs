using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kronos.Models;
using System.Data.Entity.ModelConfiguration;

namespace Kronos.Configurations
{
    public class DebtItemConfiguration : EntityTypeConfiguration<DebtItem>
    {
        public DebtItemConfiguration()
        {
            ToTable("DebtItems");

            Property(x => x.Id).IsRequired();
            Property(x => x.ProductName).IsRequired();
            Property(x => x.Value).IsRequired();
            Property(x => x.Date).IsRequired();
            HasRequired(x => x.Debt).WithMany(x => x.DebtItems);
        }
    }
}