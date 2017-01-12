using Kronos.DAL;
using Kronos.Models;
using Kronos.ViewModels;
using System;
using System.Collections.Generic;
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

        //public JsonResult GetEvents()
        //{
        //    var events = db.Events.ToList();
        //    var eventList = from e in events
        //                    select new
        //                    {
        //                        id = e.Id,
        //                        title = e.Name,
        //                        description = e.Description,
        //                        start = e.StartDate,
        //                        end = e.EndDate
        //                    };

        //    var result = eventList.ToArray();
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        public IQueryable GetEvents()
        {
            var events = db.Events;

            return events;
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View(new EventViewModel());
        }

        [HttpPost]
        public ActionResult Create(EventViewModel viewModel)
        {
            return View();
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