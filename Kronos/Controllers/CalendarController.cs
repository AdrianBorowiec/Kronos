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
    public class CalendarController : Controller
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
            Event model = new Event();

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
        public ActionResult Create(Event @event)
        {
            var validator = new EventValidator();
            var results = validator.Validate(@event);

            if (results.IsValid)
            {
                db.Events.Add(@event);
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
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }

            return View(@event);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return JavaScript(SimpleJsonSerializer.Serialize("OK"));
            }

            return View(@event);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Event @event = db.Events.Find(id);

            if (@event == null)
            {
                return HttpNotFound();
            }

            try
            {
                db.Events.Remove(@event);
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
                var toBeResized = db.Events.First(x => x.Id == id);

                db.Entry(toBeResized).State = EntityState.Modified;

                toBeResized.StartDate = e.NewStart;
                toBeResized.EndDate = e.NewEnd;

                db.SaveChanges();

                Update();
            }

            protected override void OnEventMove(EventMoveArgs e)
            {
                var id = Convert.ToInt32(e.Id);
                var toBeResized = db.Events.First(x => x.Id == id);

                db.Entry(toBeResized).State = EntityState.Modified;

                toBeResized.StartDate = e.NewStart;
                toBeResized.EndDate = e.NewEnd;

                db.SaveChanges();

                Update();
            }

            protected override void OnTimeRangeSelected(TimeRangeSelectedArgs e)
            {
                var toBeCreated = new Models.Event
                {
                    StartDate = e.Start,
                    EndDate = e.End,
                    Title = (string)e.Data["name"]
                };

                if (toBeCreated.Title != null)
                {
                    db.Events.Add(toBeCreated);
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
                        Events = db.Events.AsEnumerable();

                        DataIdField = "Id";
                        DataTextField = "Title";
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

                Events = from ev in db.Events select ev;

                DataIdField = "Id";
                DataTextField = "Title";
                DataStartField = "StartDate";
                DataEndField = "EndDate";
            }
        }
    }
}