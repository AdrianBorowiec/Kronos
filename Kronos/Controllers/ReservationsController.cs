using DayPilot.Web.Mvc;
using DayPilot.Web.Mvc.Enums;
using DayPilot.Web.Mvc.Events.Calendar;
using DayPilot.Web.Mvc.Json;
using FluentValidation.Results;
using Kronos.DAL;
using Kronos.Models;
using Kronos.Validators;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Kronos.Controllers
{
    public class ReservationsController : Controller
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
            Reservation model = new Reservation();

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
        public ActionResult Create(Reservation Reservation)
        {
            var validator = new ReservationValidator();
            var results = validator.Validate(Reservation);

            if (Reservation.ReseravtionType == ReseravtionType.Stół)
            {
                Reservation.Table = db.Tables.FirstOrDefault(x => x.TableNumber == Reservation.TableNumber);
            }

            if (results.IsValid)
            {
                db.Reservations.Add(Reservation);
                db.SaveChanges();
                
                return JavaScript(SimpleJsonSerializer.Serialize("OK"));
            }
            else
            {
                foreach (ValidationFailure failer in results.Errors)
                {
                    ModelState.AddModelError(failer.PropertyName, failer.ErrorMessage);
                }
            }

            return View(Reservation);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation Reservation = db.Reservations.Find(id);
            if (Reservation == null)
            {
                return HttpNotFound();
            }

            return View(Reservation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Reservation Reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Reservation).State = EntityState.Modified;
                db.SaveChanges();
                return JavaScript(SimpleJsonSerializer.Serialize("OK"));
            }

            return View(Reservation);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Reservation Reservation = db.Reservations.Find(id);

            if (Reservation == null)
            {
                return HttpNotFound();
            }

            try
            {
                db.Reservations.Remove(Reservation);
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
                var toBeResized = db.Reservations.First(x => x.Id == id);

                db.Entry(toBeResized).State = EntityState.Modified;

                toBeResized.StartDate = e.NewStart;
                toBeResized.EndDate = e.NewEnd;

                db.SaveChanges();

                Update();
            }

            protected override void OnEventMove(EventMoveArgs e)
            {
                var id = Convert.ToInt32(e.Id);
                var toBeResized = db.Reservations.First(x => x.Id == id);

                db.Entry(toBeResized).State = EntityState.Modified;

                toBeResized.StartDate = e.NewStart;
                toBeResized.EndDate = e.NewEnd;

                db.SaveChanges();

                Update();
            }

            protected override void OnTimeRangeSelected(TimeRangeSelectedArgs e)
            {
                var toBeCreated = new Reservation
                {
                    StartDate = e.Start,
                    EndDate = e.End,
                    ClientName = (string)e.Data["name"],
                };

                if (toBeCreated.ClientName != null)
                {
                    db.Reservations.Add(toBeCreated);
                    db.SaveChanges();

                    Update();
                }
            }

            protected override void OnCommand(CommandArgs e)
            {
                switch (e.Command)
                {
                    case "previous":
                        StartDate = StartDate.AddDays(-1);
                        Update(CallBackUpdateType.Full);
                        break;
                    case "next":
                        StartDate = StartDate.AddDays(1);
                        Update(CallBackUpdateType.Full);
                        break;
                    case "today":
                        StartDate = DateTime.Today;
                        Update(CallBackUpdateType.Full);
                        break;
                    case "refresh":
                        Events = db.Reservations.AsEnumerable();

                        foreach(Reservation item in Events)
                        {
                            if (item.ClientName != null && item.StartDate != null && EndDate != null && item.ReseravtionType != null)
                            {
                                if (item.ReseravtionType == Kronos.Models.ReseravtionType.Stół)
                                {
                                    item.EventName = String.Format("{0} (Stół nr {1}) {2:00}:{3:00} - {4:00}:{5:00}", item.ClientName, item.TableNumber, item.StartDate.Value.Hour, item.StartDate.Value.Minute, item.EndDate.Value.Hour, item.EndDate.Value.Minute);
                                }
                                else
                                {
                                    item.EventName = String.Format("{0} ({1}) {2:00}:{3:00} - {4:00}:{5:00}", item.ClientName, item.ReseravtionType.Value, item.StartDate.Value.Hour, item.StartDate.Value.Minute, item.EndDate.Value.Hour, item.EndDate.Value.Minute);
                                }
                            }
                        }

                        DataIdField = "Id";
                        DataTextField = "EventName";
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

                Events = from ev in db.Reservations select ev;

                foreach (Reservation item in Events)
                {
                    if (item.ClientName != null && item.StartDate != null && EndDate != null && item.ReseravtionType != null)
                    {
                        if (item.ReseravtionType == Kronos.Models.ReseravtionType.Stół)
                        {
                            item.EventName = String.Format("{0} (Stół nr {1}) {2:00}:{3:00} - {4:00}:{5:00}", item.ClientName, item.TableNumber, item.StartDate.Value.Hour, item.StartDate.Value.Minute, item.EndDate.Value.Hour, item.EndDate.Value.Minute);
                        }
                        else
                        {
                            item.EventName = String.Format("{0} ({1}) {2:00}:{3:00} - {4:00}:{5:00}", item.ClientName, item.ReseravtionType.Value, item.StartDate.Value.Hour, item.StartDate.Value.Minute, item.EndDate.Value.Hour, item.EndDate.Value.Minute);
                        }
                    }
                }

                DataIdField = "Id";
                DataTextField = "EventName";
                DataStartField = "StartDate";
                DataEndField = "EndDate";
            }
        }
    }
}