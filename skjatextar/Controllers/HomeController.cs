using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace skjatextar.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Þið eruð allir fávitar";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "smuuu";

            return View();
        }
    }
}