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