using Kronos.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kronos.Controllers
{
    public class ShoppingListController : Controller
    {
        private Db db = new Db();

        // GET: ShoppingList
        public ActionResult Index()
        {
            return View();
        }
    }
}