using skjatextar.Models;
//using skjatextar.Repos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace skjatextar.Controllers
{
    public class TranslationController : Controller
    {
        TranslationRepository repo = new TranslationRepository();
        VideoRepository videorepo = new VideoRepository();

       
        //
        // GET: /Translation/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }


        [HttpGet]
        public ActionResult LoadNewFile()
        {
            IEnumerable<Video> videos = videorepo.GetAllVideos();

            return View(videos);
        }

        [HttpPost]
        public ActionResult LoadNewFile(HttpPostedFileBase Translation)
        {
            IEnumerable<Video> videos = videorepo.GetAllVideos();
            if (ModelState.IsValid)
            {
                if (Translation == null)
                {
                    ModelState.AddModelError("File", "Vinsamlegast veldu skrá");
                }
                else if (Translation.ContentLength > 0)
                {
                    string[] AllowedFileType = new string[] {".srt", ".txt"};

                    if (!AllowedFileType.Contains(Translation.FileName.Substring(Translation.FileName.LastIndexOf('.'))))
                    {
                        ModelState.AddModelError("File", "Aðeins eru leyfðar skrár af gerðinni: " + string.Join(", ", AllowedFileType));
                    }
                    else
                    {
                        //TO:DO
                        var FileName = Path.GetFileName(Translation.FileName);
                        var path = Path.Combine(Server.MapPath("~/Uploads/test.srt"));
                        Translation.SaveAs(path);
                        ModelState.Clear();
                        Translation item = new Translation();
                        StreamReader file = new StreamReader(FileName);
                        item.Text = file.ReadLine();
                        item.Title = Translation.FileName;
                        item.LikeCount = 0;
                        item.DateLastEdited = DateTime.Now;
                        //item.VideoID = null;
                        repo.AddTranslation(item);
                        ViewBag.Message = "Það tókst að hlaða upp skránni";
                    }
                }
            }
            return View(videos);
        }
 

        //
        // GET: /Translation/Edit/5
        public ActionResult Edit(int? id)
        {
            var newItem = repo.GetTranslationById(id.Value);//ná í upplýsingarnar úr fréttinni
            if (newItem != null)//ef newItem er ekki null
            {
                return View(newItem);
            }
            return View("Error");//error síða
        }

        //
        // POST: /Translation/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, FormCollection FormData)
        {
            Translation item = repo.GetTranslationById(id.Value);//tekur upplýsingarnar með inní edit gluggan

            item.Title = FormData["Title"];
            item.Text = FormData["Text"];

            if ((item.Title == "") || (item.Text == ""))//ef title eða text er tómt þá error
            {
                return View("Error");
            }
            UpdateModel(item);
            repo.UpdateTranslation(item);

            repo.Save();
            return RedirectToAction("Edit");
        }

        public IView translations { get; set; }
    }
}
