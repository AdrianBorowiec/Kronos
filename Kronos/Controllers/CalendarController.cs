using DayPilot.Web.Mvc;
using DayPilot.Web.Mvc.Enums;
using DayPilot.Web.Mvc.Events.Calendar;
using Kronos.DAL;
using Kronos.Infrastructure;
using Kronos.Models;
using Kronos.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
                var toBeCreated = new Event
                {
                    StartDate = e.Start,
                    EndDate = e.End,
                    Name = (string)e.Data["name"]
                };

                if (toBeCreated.Name != null)
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
                DataTextField = "Name";
                DataStartField = "StartDate";
                DataEndField = "EndDate";
            }
        }
    }
}