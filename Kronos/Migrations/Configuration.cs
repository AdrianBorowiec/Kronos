namespace Kronos.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Kronos.DAL.Db>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Db ctx)
        {
            var employees = new List<Employee>
            {
                new Employee { FirstName = "Adrian", LastName = "Borowiec", Password = "pass" },
            };

            employees.ForEach(x => ctx.Employees.AddOrUpdate(n => new { n.FirstName, n.LastName }, x));
            ctx.SaveChanges();
        }
    }
}
