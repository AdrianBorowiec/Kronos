using Kronos.DAL;
using Kronos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Kronos.Controllers
{
    public class DebtItemsController : Controller
    {
        private Db db = new Db();

        public ActionResult Index()
        {
            return View(db.Debts.ToList());
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DebtItem debtItem = db.DebtItems.Find(id);

            if (debtItem == null)
            {
                return HttpNotFound();
            }

            try
            {
                db.DebtItems.Remove(debtItem);
                db.SaveChanges();
                return Content("true");
            }
            catch
            {
                return Content("false");
            }
        }
    }
}