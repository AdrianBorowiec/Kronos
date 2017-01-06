using Kronos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Kronos.Configurations
{
    public class RequisitionItemConfiguration : EntityTypeConfiguration<RequisitionItem>
    {
        public RequisitionItemConfiguration()
        {
            ToTable("RequisitionItems");

            Property(x => x.Id).IsRequired();
            Property(x => x.Name).IsRequired();
            Property(x => x.CreateDate).IsRequired();
            Property(x => x.RequisitionType).IsRequired();
        }
    }
}