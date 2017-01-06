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
    public class DebtController : Controller
    {
        private Db db = new Db();

        public ActionResult Index()
        {
            return View(db.Debts.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Debt debt = db.Debts.Find(id);

            if (debt == null)
            {
                return HttpNotFound();
            }

            try
            {
                db.Debts.Remove(debt);
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