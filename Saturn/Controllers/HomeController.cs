using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saturn.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Mambru se fue a la guerra";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Que dolor que dolor que pena";

            return View();
        }
    }
}