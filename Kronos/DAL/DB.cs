using Kronos.Configurations;
using Kronos.Infrastructure;
using Kronos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Kronos.DAL
{
    public class Db : DbContext
    {
        public Db()
            : base("ConnectionString")
        {
        }

        public DbSet<RequisitionItem> RequisitionItems { get; set; }
        public DbSet<Debt> Debts { get; set; }
        public DbSet<DebtItem> DebtItems { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ustawienia ogólne.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.AddBefore<ForeignKeyIndexConvention>(new ForeignKeyNamingConvention());
            this.Configuration.LazyLoadingEnabled = true;
            //

            modelBuilder.Configurations.Add(new RequisitionItemConfiguration());
            modelBuilder.Configurations.Add(new DebtConfiguration());
            modelBuilder.Configurations.Add(new DebtItemConfiguration());
        }
    }
}