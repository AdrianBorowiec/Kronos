using Kronos.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kronos.Infrastructure
{
    public class SelectListItemsHelper
    {
        public static IEnumerable<SelectListItem> GetTablesList()
        {
            IList<SelectListItem> list = new List<SelectListItem>();
            Db db = new Db();

            foreach (var item in db.Tables.ToList())
            {
                list.Add(new SelectListItem { Text = "Stół nr " + item.TableNumber.ToString(), Value = item.TableNumber.ToString() });
            }

            return list;
        }
    }
}