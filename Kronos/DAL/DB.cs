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

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ustawienia ogólne.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.AddBefore<ForeignKeyIndexConvention>(new ForeignKeyNamingConvention());
            this.Configuration.LazyLoadingEnabled = true;
            //

            modelBuilder.Configurations.Add(new UserConfiguration());
        }
    }
}