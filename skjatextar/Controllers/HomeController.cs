using skjatextar.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;

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

        [HttpGet]
        public ActionResult LoadNewFile()
        {
            return View(new TranslationViewModel());
        }

        [HttpGet]
        public ActionResult ViewTranslation(int? id)   //  Ef ekki er slegid inn id, kemur tom sida.
        {
            if (id.HasValue)
            {
                int realid = id.Value;
                TranslationRepository repo3 = new TranslationRepository();
                var model = repo3.GetTranslationById(realid);
                return View(model);
            }
            return View("Error");
        }

        [HttpPost]
        public void ViewTranslation(int id, object sender, EventArgs e)
        {
            Translation s = repo.GetTranslationById(id);
            // Write the string to a file.
            StreamWriter file = new StreamWriter("c:/Users/Petur/Documents/prufa/test.srt");
            file.WriteLine(s.Text);
            file.Close();
            /*string filePath = lblFilename.Text;

            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
            Response.TransmitFile(Server.MapPath(filePath));
            Response.End();*/
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