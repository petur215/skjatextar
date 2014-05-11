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
            var newest10 = repo.GetAllTranslations().Take(10).ToList(); // skilar nyjustu 10 þýðingunum

            return View(newest10);
        }
        //
        [HttpGet]
        public ActionResult ViewTranslation(int? id)   //  Ef ekki er slegid inn id, kemur tom sida.
        {
            if(id.HasValue)
            {
                int realid = id.Value;
                TranslationRepository repo = new TranslationRepository();
                var model = repo.GetTranslationById(realid);
                return View(model);
            }
            return View("Error");
        }

        [HttpPost]
        public ActionResult ViewTranslation(int id)
        {
            TranslationRepository repo = new TranslationRepository();
            Translation s = repo.GetTranslationById(id);
            if(s != null)
            {
                UpdateModel(s);
                repo.UpdateTranslation(s);
                return RedirectToAction("Index");
            }
            else
            {
                return View("NotFound");
            }
        }
        //
        public ActionResult LoadNewFile()
        {
            ViewBag.Message = "smuuu";

            return View();
        }
        public ActionResult Requests()
        {
            ViewBag.Message = "trolololololol";

            return View();
        }
        public ActionResult Rules()
        {
            ViewBag.Message = "Reglur eru til þess að fara eftir þeim!";

            return View();
        }

        public ViewResult About()
        {
            throw new NotImplementedException();
        }

        public ViewResult Contact()
        {
            throw new NotImplementedException();
        }
    }
}