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
    public class RequisitionItemsController : Controller
    {
        private Db db = new Db();

        // GET: RequisitionItems
        public ActionResult Index()
        {
            return View(db.RequisitionItems.ToList());
        }

        // GET: RequisitionItems/Details/5
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

        // GET: RequisitionItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RequisitionItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // [Bind(Include = "Id,Name,Quantity,RequisitionType")] 
        public ActionResult Create(RequisitionItem requisitionItem)
        {
            requisitionItem.CreateDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.RequisitionItems.Add(requisitionItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(requisitionItem);
        }

        // GET: RequisitionItems/Edit/5
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

        // POST: RequisitionItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
