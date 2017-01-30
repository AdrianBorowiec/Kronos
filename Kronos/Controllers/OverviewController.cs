using FluentValidation.Results;
using Kronos.DAL;
using Kronos.Models;
using Kronos.Validators;
using Kronos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kronos.Controllers
{
    public class OverviewController : Controller
    {
        private Db db = new Db();

        public ActionResult Index()
        {
            var model = new OverviewViewModel();

            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                var model = new OverviewDetailsViewModel();

                model.CurrentReservation = db.Reservations.SingleOrDefault(x => x.Table.Id == id && x.StartDate <= DateTime.Now && x.EndDate >= DateTime.Now);
                model.Reservations = db.Reservations.Where(x => x.Table.Id == id && x.StartDate > DateTime.Now && x.EndDate > DateTime.Now).OrderByDescending(x => x.StartDate);
                model.Table = db.Tables.Single(x => x.Id == id);

                return View(model);
            }
            else
            {
                return HttpNotFound();
            }      
        }

        [HttpGet]
        public ActionResult AddReservation(int? tableId)
        {
            var model = new Reservation();

            if (tableId == null)
            {
                return HttpNotFound();
            }
            else
            {
                model.ReseravtionType = ReseravtionType.Stół;
                model.Table = db.Tables.Single(x => x.Id == tableId);
                model.TableNumber = model.Table.TableNumber;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult AddReservation(Reservation reservation)
        {
            reservation.Table = db.Tables.Single(x => x.TableNumber == reservation.TableNumber);
            reservation.ReseravtionType = ReseravtionType.Stół;

            var validator = new ReservationValidator();
            var results = validator.Validate(reservation);

            if (results.IsValid)
            {
                db.Reservations.Add(reservation);
                db.SaveChanges();

                return Redirect("/Overview/Details/" + reservation.Table.Id.ToString());
            }
            else
            {
                foreach (ValidationFailure failer in results.Errors)
                {
                    ModelState.AddModelError(failer.PropertyName, failer.ErrorMessage);
                }
            }

            return View(reservation);
        }
    }
}