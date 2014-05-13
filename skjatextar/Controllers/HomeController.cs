using skjatextar.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using skjatextar.Repos;
using skjatextar.DAL;
using System.Text;


namespace skjatextar.Controllers
{
    public class HomeController : Controller
    {
        TranslationRepository repo = new TranslationRepository();
        
        public ActionResult Index()
        {
            //var newest10 = repo.GetAllTranslations().Take(10).ToList(); // skilar nyjustu 10 þýðingunum
            //return View(newest10);
            IndexViewModel result = new IndexViewModel();

            result.Top10 = (from s in repo.GetAllTranslations()
                               orderby s.LikeCount descending
                               select s).Take(10);
            result.Newest10 = (from r in repo.GetAllTranslations()
                               orderby r.DateLastEdited descending
                               select r).Take(10);
                
            return View(result);
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
                //var model = commentRepo.GetComments(); ???
                model.LikeCount = repo.AllLikes(realid);
                string username = User.Identity.Name;
                return View(model);
            }
            return View("Error");
        }
        public FileStreamResult DownloadTranslation(int? id)
        {
            Translation s = repo.GetTranslationById(id.Value);
            // Write the string to a file.
            StreamWriter file = new StreamWriter("~/Uploads/test.srt");
            file.WriteLine(s.Text);
            file.Close();
            var content = s.Text;
            content = content.Replace("@", System.Environment.NewLine);
            var byteArray = Encoding.ASCII.GetBytes(content);
            var stream = new MemoryStream(byteArray);

            return File(stream, "text/plain", s.Title + ".srt");
        }
        [HttpPost]
        public ActionResult LikeFunction(int id)
        {
            Likes item = new Likes();
            UpdateModel(item);
            item.TranslationID = id;
            item.UserName = User.Identity.Name;
            repo.AddLike(item);

            return View("ViewTranslation");
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