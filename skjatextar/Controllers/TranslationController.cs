using skjatextar.Models;
//using skjatextar.Repos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace skjatextar.Controllers
{
    public class TranslationController : Controller
    {
        TranslationRepository repo = new TranslationRepository();
        VideoRepository videorepo = new VideoRepository();

        

        [HttpGet]
        public ActionResult LoadNewFile()
        {
            IEnumerable<Video> videos = videorepo.GetAllVideos();

            return View(videos);
        }

        [HttpPost]
        [Authorize]
        public ActionResult LoadNewFile(HttpPostedFileBase Translation)
        {
            IEnumerable<Video> videos = videorepo.GetAllVideos();
            if (ModelState.IsValid)
            {
                if (Translation == null)//ef enginn skrá er valinn
                {
                    ModelState.AddModelError("File", "Vinsamlegast veldu skrá");
                }
                else if (Translation.ContentLength > 0) 
                {
                    string[] AllowedFileType = new string[] {".srt", ".txt"}; //leyfðar skráargerðir

                    if (!AllowedFileType.Contains(Translation.FileName.Substring(Translation.FileName.LastIndexOf('.'))))//ef skráin er af annarri týpu
                    {
                        ModelState.AddModelError("File", "Aðeins eru leyfðar skrár af gerðinni: " + string.Join(", ", AllowedFileType));
                    }
                    else
                    {
                        var FileName = Path.GetFileName(Translation.FileName);
                        var path = Path.Combine(Server.MapPath("~/Uploads/"), FileName);
                        Translation.SaveAs(path);
                        ModelState.Clear();
                        Translation item = new Translation();
                        StreamReader file = new StreamReader(path, Encoding.Default, true);
                        UpdateModel(item);
                        item.Text = file.ReadToEnd();
                        string str = Translation.FileName;
                        str = str.Remove(str.Length - 4);
                        item.Title = str;
                        item.LikeCount = 0;
                        item.DateLastEdited = DateTime.Now;
                        string Name = Request.Form["ValinMynd"];
                        file.Close();
                        videorepo.Save();
                        if(item.DeafCheck != null)//
                        {
                            item.DeafCheck = "Já";
                        }
                        else
                        {
                            item.DeafCheck = "Nei";
                        }
                        var choosenvid = videorepo.GetVideoByName(Name);
                        item.VideoID = choosenvid.ID;
                        choosenvid.TranslationCount += 1;
                        videorepo.Save();
                        repo.AddTranslation(item);
                        ViewBag.Message = ("Það Tókst að hlaða upp skránni");
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
        [Authorize]
        public ActionResult Edit(int? id, FormCollection FormData)
        {
            Translation item = repo.GetTranslationById(id.Value);//tekur upplýsingarnar með inní edit gluggan

            item.Text = FormData["Text"];

            if (((item.Text == "")))//ef title eða text er tómt þá error
            {
                return View("Error");
            }
            UpdateModel(item);
            repo.UpdateTranslation(item);
            item.DateLastEdited = DateTime.Now;
            repo.Save();
            ViewBag.Message = ("Skráin hefur verið vistuð");
            return RedirectToAction("Edit");
        }

        public IView translations { get; set; }
    }
}
