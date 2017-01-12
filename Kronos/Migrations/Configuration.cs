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
            //var employees = new List<Employee>
            //{
            //    new Employee { FirstName = "Adrian", LastName = "Borowiec", Password = "pass" },
            //};

            //employees.ForEach(x => ctx.Employees.AddOrUpdate(n => new { n.FirstName, n.LastName }, x));
            //ctx.SaveChanges();

            // testowe wydarzenia
            var events = new List<Event>
            {
                new Event { Name = "Test1", Description = "Opis test1", StartDate = new DateTime(2017, 1, 3, 12, 0, 0), EndDate = new DateTime(2017, 1, 3, 14, 0, 0) },
                new Event { Name = "Test2", Description = "Opis test2", StartDate = new DateTime(2017, 1, 4, 9, 30, 0), EndDate = new DateTime(2017, 1, 4, 10, 0, 0) },
                new Event { Name = "Test3", Description = "Opis test3", StartDate = new DateTime(2017, 1, 5, 18, 0, 0), EndDate = new DateTime(2017, 1, 5, 20, 0, 0) },
                new Event { Name = "Test4", Description = "Opis test4", StartDate = new DateTime(2017, 1, 3, 11, 0, 0), EndDate = new DateTime(2017, 1, 3, 15, 0, 0) },
                new Event { Name = "Test5", Description = "Opis test5", StartDate = new DateTime(2017, 1, 3, 10, 0, 0), EndDate = new DateTime(2017, 1, 3, 12, 30, 0) },
                new Event { Name = "Test6", Description = "Opis test6", StartDate = new DateTime(2017, 1, 4, 17, 0, 0), EndDate = new DateTime(2017, 1, 4, 18, 0, 0) },
            };

            events.ForEach(x => ctx.Events.AddOrUpdate(n => n.Id, x));
            ctx.SaveChanges();
        }
    }
}
