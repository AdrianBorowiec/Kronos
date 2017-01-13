using DayPilot.Web.Mvc;
using DayPilot.Web.Mvc.Enums;
using DayPilot.Web.Mvc.Events.Calendar;
using DayPilot.Web.Mvc.Json;
using Kronos.DAL;
using Kronos.Infrastructure;
using Kronos.Models;
using Kronos.Validators;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Kronos.Controllers
{
    public class WorkHoursController : Controller
    {
        private Db db = new Db();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Backend()
        {
            return new DPC().CallBack(this);
        }

        [HttpGet]
        public ActionResult Create()
        {
            string start = Request.QueryString["start"];
            string end = Request.QueryString["end"];
            DateTime startDT;
            DateTime endDT;
            WorkHours model = new WorkHours();

            if (start != "" && end != "")
            {
                if (!DateTime.TryParse(start, out startDT))
                {
                    startDT = DateTime.ParseExact(start, "yyyy-MM-ddT24:mm:ssK", CultureInfo.InvariantCulture);
                    startDT = startDT.AddDays(1);
                }
                if (!DateTime.TryParse(end, out endDT))
                {
                    endDT = DateTime.ParseExact(end, "yyyy-MM-ddT24:mm:ssK", CultureInfo.InvariantCulture);
                    endDT = endDT.AddDays(1);
                }

                model.StartDate = startDT;
                model.EndDate = endDT;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(WorkHours workHours)
        {
            var validator = new WorkHoursValidator();
            var results = validator.Validate(workHours);

            if (results.IsValid)
            {
                db.WorkHours.Add(workHours);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return JavaScript(SimpleJsonSerializer.Serialize("OK"));
            }

            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkHours workHours = db.WorkHours.Find(id);
            if (workHours == null)
            {
                return HttpNotFound();
            }

            return View(workHours);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WorkHours workHours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workHours).State = EntityState.Modified;
                db.SaveChanges();
                return JavaScript(SimpleJsonSerializer.Serialize("OK"));
            }

            return View(workHours);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            WorkHours workHours = db.WorkHours.Find(id);

            if (workHours == null)
            {
                return HttpNotFound();
            }

            try
            {
                db.WorkHours.Remove(workHours);
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





        class DPC : DayPilotCalendar
        {
            private Db db = new Db();

            protected override void OnInit(InitArgs e)
            {
                Update(CallBackUpdateType.Full);
            }

            protected override void OnEventResize(EventResizeArgs e)
            {
                var id = Convert.ToInt32(e.Id);
                var toBeResized = db.WorkHours.First(x => x.Id == id);

                db.Entry(toBeResized).State = EntityState.Modified;

                toBeResized.StartDate = e.NewStart;
                toBeResized.EndDate = e.NewEnd;

                db.SaveChanges();

                Update();
            }

            protected override void OnEventMove(EventMoveArgs e)
            {
                var id = Convert.ToInt32(e.Id);
                var toBeResized = db.WorkHours.First(x => x.Id == id);

                db.Entry(toBeResized).State = EntityState.Modified;

                toBeResized.StartDate = e.NewStart;
                toBeResized.EndDate = e.NewEnd;

                db.SaveChanges();

                Update();
            }

            protected override void OnTimeRangeSelected(TimeRangeSelectedArgs e)
            {
                var toBeCreated = new Models.WorkHours
                {
                    StartDate = e.Start,
                    EndDate = e.End,
                    Employee = (string)e.Data["name"]
                };

                if (toBeCreated.Employee != null)
                {
                    db.WorkHours.Add(toBeCreated);
                    db.SaveChanges();

                    Update();
                }
            }

            protected override void OnCommand(CommandArgs e)
            {
                switch(e.Command)
                {
                    case "previous":
                        StartDate = StartDate.AddDays(-7);
                        Update(CallBackUpdateType.Full);
                        break;
                    case "next":
                        StartDate = StartDate.AddDays(7);
                        Update(CallBackUpdateType.Full);
                        break;
                    case "today":
                        StartDate = DateTime.Today;
                        Update(CallBackUpdateType.Full);
                        break;
                    case "refresh":
                        Events = db.WorkHours.AsEnumerable();

                        DataIdField = "Id";
                        DataTextField = "Employee";
                        DataStartField = "StartDate";
                        DataEndField = "EndDate";

                        Update();
                        break;
                }
            }

            protected override void OnFinish()
            {
                if (UpdateType == CallBackUpdateType.None)
                {
                    return;
                }

                Events = from ev in db.WorkHours select ev;

                DataIdField = "Id";
                DataTextField = "Employee";
                DataStartField = "StartDate";
                DataEndField = "EndDate";
            }
        }
    }
}