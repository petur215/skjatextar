using skjatextar.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace skjatextar.Controllers
{
    public class HomeController : Controller
    {
        TranslationRepository repo = new TranslationRepository();

        public ActionResult Index()
        {
            IEnumerable<Translation> newest10 = repo.Newsest10();

            return View(newest10);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Þið eruð allir mongóar";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "smuuu";

            return View();
        }
    }

+

3
















































,,,,,


,,,,,,,,,,,,,,,,,,,,,,,}