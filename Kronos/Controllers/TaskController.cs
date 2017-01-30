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
    public class TaskController : Controller
    {
        private Db db = new Db();

        public ActionResult Index()
        {
            return View(db.Tasks.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Employee,TaskDescription,TaskDate,Status")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(task);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Employee,TaskDescription,TaskDate,Status")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Task task = db.Tasks.Find(id);

            if (task == null)
            {
                return HttpNotFound();
            }

            try
            {
                db.Tasks.Remove(task);
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

        public ActionResult ChangeStatus(int? id, bool status)
        {
            var task = db.Tasks.FirstOrDefault(x => x.Id == id);

            if (task == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            db.Entry(task).State = EntityState.Modified;
            task.Status = !status;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
