using Kronos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Kronos.Configurations
{
    public class EventConfiguration : EntityTypeConfiguration<Event>
    {
        public EventConfiguration()
        {
            ToTable("Events");

            Property(x => x.Id).IsRequired();
            Property(x => x.Name).IsRequired();
            Property(x => x.StartDate).IsRequired();
            Property(x => x.EndDate).IsRequired();
        }
    }
}