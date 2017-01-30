using Kronos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Kronos.Configurations
{
    public class TableConfiguration : EntityTypeConfiguration<Table>
    {
        public TableConfiguration()
        {
            ToTable("Tables");

            Property(x => x.Id).IsRequired();
            Property(x => x.TableNumber).IsRequired();
            //Property(x => x.IsFree).IsRequired();
        }
    }
}