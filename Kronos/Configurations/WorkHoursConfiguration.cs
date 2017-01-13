using Kronos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Kronos.Configurations
{
    public class WorkHoursConfiguration : EntityTypeConfiguration<WorkHours>
    {
        public WorkHoursConfiguration()
        {
            ToTable("WorkHours");

            Property(x => x.Id).IsRequired();
            Property(x => x.Employee).IsRequired();
            Property(x => x.StartDate).IsRequired();
            Property(x => x.EndDate).IsRequired();
        }
    }
}