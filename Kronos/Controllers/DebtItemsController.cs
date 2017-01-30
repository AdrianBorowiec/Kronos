using Kronos.DAL;
using Kronos.Models;
using Kronos.Validators;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Kronos.Controllers
{
    public class DebtItemsController : Controller
    {
        private Db db = new Db();

        public ActionResult Index(int? debtId)
        {
            if (debtId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.DebtId = debtId;
            ViewBag.Debtor = db.Debts.FirstOrDefault(x => x.Id == debtId).Debtor;
            var debtItems = db.DebtItems.Where(x => x.Debt.Id == debtId).ToList();

            foreach (var item in debtItems)
            {
                item.TotalValue = item.Quantity * item.Value;
            }

            return View(debtItems);
        }

        [HttpGet]
        public ActionResult Create(int? debtId)
        {
            ViewBag.DebtId = debtId;
            return View();
        }

        [HttpPost]
        public ActionResult Create(DebtItem debtItem)
        {
            debtItem.Date = DateTime.Now;

            var urlString = Request.UrlReferrer.Query;
            var debtId = Int32.Parse(urlString.Substring(urlString.LastIndexOf('=') + 1));

            var validator = new DebtItemValidator(debtId);
            var results = validator.Validate(debtItem);

            if (results.IsValid)
            {
                debtItem.Debt = db.Debts.FirstOrDefault(x => x.Id == debtId);
                db.DebtItems.Add(debtItem);
                db.SaveChanges();
                return RedirectToAction("Index", new { debtId = debtId });
            }

            return RedirectToAction("Create", new { debtId = debtId });
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

        public ActionResult AddItem(DebtItem model)
        {
            var urlString = Request.UrlReferrer.Query;
            var debtId = Int32.Parse(urlString.Substring(urlString.LastIndexOf('=') + 1));

            model.Quantity++;
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();            

            return RedirectToAction("Index", new { debtId = debtId });
        }

        public ActionResult DeleteItem(DebtItem model)
        {
            var urlString = Request.UrlReferrer.Query;
            var debtId = Int32.Parse(urlString.Substring(urlString.LastIndexOf('=') + 1));

            if (model.Quantity <= 0)
            {
                return RedirectToAction("Index", new { debtId = debtId });
            }

            model.Quantity--;          
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", new { debtId = debtId });
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