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
        
        public DbSet<Debt> Debts { get; set; }
        public DbSet<DebtItem> DebtItems { get; set; }
        public DbSet<Earning> Earnings { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<RequisitionItem> RequisitionItems { get; set; }        
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<WorkHours> WorkHours { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.AddBefore<ForeignKeyIndexConvention>(new ForeignKeyNamingConvention());
            this.Configuration.LazyLoadingEnabled = true;
            
            modelBuilder.Configurations.Add(new DebtConfiguration());
            modelBuilder.Configurations.Add(new DebtItemConfiguration());
            modelBuilder.Configurations.Add(new EarningConfiguration());
            modelBuilder.Configurations.Add(new TableConfiguration());
            modelBuilder.Configurations.Add(new TaskConfiguration());
            modelBuilder.Configurations.Add(new RequisitionItemConfiguration());
            modelBuilder.Configurations.Add(new ReservationConfiguration());
            modelBuilder.Configurations.Add(new WorkHoursConfiguration());
        }
    }
}