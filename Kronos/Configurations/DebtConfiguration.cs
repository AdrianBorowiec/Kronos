using Kronos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Kronos.Configurations
{
    public class DebtConfiguration : EntityTypeConfiguration<Debt>
    {
        public DebtConfiguration()
        {
            ToTable("Debts");

            Property(x => x.Id).IsRequired();
            Property(x => x.Debtor).IsRequired();
        }
    }
}