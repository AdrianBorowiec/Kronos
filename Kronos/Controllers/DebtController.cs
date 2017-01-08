using Kronos.DAL;
using Kronos.Models;
using Kronos.Validators;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            foreach (var item in db.Debts.ToList())
            {
                item.TotalAmount = item.DebtItems.Sum(x => x.Value * x.Quantity);
            }

            db.SaveChanges();

            return View(db.Debts.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Debt debt)
        {
            var validator = new DebtValidator();
            var results = validator.Validate(debt);

            if (results.IsValid)
            {
                db.Debts.Add(debt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(debt);
        }

        public ActionResult Details(int? id)
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

            return View(debt);
        }

        public ActionResult Edit(int? id)
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
            return View(debt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Debt debt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(debt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(debt);
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}