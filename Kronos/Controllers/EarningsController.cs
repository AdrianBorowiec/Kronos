using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kronos.DAL;
using Kronos.Models;

namespace Kronos.Controllers
{
    public class EarningsController : Controller
    {
        private Db db = new Db();

        public ActionResult Index()
        {
            return View(db.Earnings.ToList());
        }

        public ActionResult Create()
        {
            var model = new Earning();
            //model.Date = DateTime.Today;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Earning earning)
        {
            if (ModelState.IsValid)
            {
                earning.Sum = earning.ByCart + earning.ByCash;
                db.Earnings.Add(earning);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(earning);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Earning earning = db.Earnings.Find(id);
            if (earning == null)
            {
                return HttpNotFound();
            }
            return View(earning);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Earning earning)
        {
            if (ModelState.IsValid)
            {
                db.Entry(earning).State = EntityState.Modified;
                earning.Sum = earning.ByCart + earning.ByCash;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(earning);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Earning earning = db.Earnings.Find(id);

            if (earning == null)
            {
                return HttpNotFound();
            }

            try
            {
                db.Earnings.Remove(earning);
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
