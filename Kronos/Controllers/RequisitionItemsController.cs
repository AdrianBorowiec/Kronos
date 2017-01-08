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
using Kronos.Validators;

namespace Kronos.Controllers
{
    public class RequisitionItemsController : Controller
    {
        private Db db = new Db();

        public ActionResult Index()
        {
            return View(db.RequisitionItems.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequisitionItem requisitionItem = db.RequisitionItems.Find(id);
            if (requisitionItem == null)
            {
                return HttpNotFound();
            }
            return View(requisitionItem);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RequisitionItem requisitionItem)
        {
            requisitionItem.CreateDate = DateTime.Now;
            var validator = new RequisitionItemValidator();
            var result = validator.Validate(requisitionItem);

            if (result.IsValid)
            {
                db.RequisitionItems.Add(requisitionItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(requisitionItem);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequisitionItem requisitionItem = db.RequisitionItems.Find(id);
            if (requisitionItem == null)
            {
                return HttpNotFound();
            }
            return View(requisitionItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Quantity,CreateDate,RequisitionType")] RequisitionItem requisitionItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requisitionItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(requisitionItem);
        }
        
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RequisitionItem requisitionItem = db.RequisitionItems.Find(id);

            if (requisitionItem == null)
            {
                return HttpNotFound();
            }

            try
            {
                db.RequisitionItems.Remove(requisitionItem);
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
