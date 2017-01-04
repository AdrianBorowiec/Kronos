using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Kronos.Infrastructure
{
    public class ForeignKeyNamingConvention : IStoreModelConvention<AssociationType>
    {
        public void Apply(AssociationType item, DbModel model)
        {
            if (item.IsForeignKey && item.Constraint.FromProperties.Count == item.Constraint.ToProperties.Count)
            {
                for (int i = 0; i < item.Constraint.FromProperties.Count; i++)
                {
                    var pFrom = item.Constraint.FromProperties[i];
                    var pTo = item.Constraint.ToProperties[i];

                    if (pFrom.Name.EndsWith("_" + pTo.Name) && pFrom.Name.Count(x => x == '_') == 1)
                    {
                        pFrom.Name = pFrom.Name.Replace("_", "");
                    }
                }

                for (int i = 0; i < item.Constraint.ToProperties.Count; i++)
                {
                    var pFrom = item.Constraint.FromProperties[i];
                    var pTo = item.Constraint.ToProperties[i];

                    if (pTo.Name.EndsWith("_" + pFrom.Name) && pTo.Name.Count(x => x == '_') == 1)
                    {
                        pTo.Name = pTo.Name.Replace("_", "");
                    }
                }
            }
        }
    }
}