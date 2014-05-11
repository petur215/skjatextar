using skjatextar.Models;
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
        // GET: /Translation/
        public ActionResult Translations()
        {
            //var translations = repo.GetAllTranslations().ToList;

            //IEnumerable<Video> newest10 = repo.Newest10();

            //return View(newest10);
            var translations = repo.GetAllTranslations();
            var newest = (from n in translations orderby n.Title select n).Take(10);

            return View(newest);
            //return View(translations);
        }

        //
        // GET: /Translation/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }


        [HttpGet]
        public ActionResult LoadNewFile()
        {
            return View(new TranslationViewModel());
        }

        [HttpPost]
        public ActionResult LoadNewFile(TranslationViewModel s, HttpPostedFileBase file)
        {

            if (ModelState.IsValid)
            {
                Translation t = new Translation();
                t.ID = s.ID;
                t.Title = s.Title;
                t.Text = s.Text;
                t.LikeCount = s.LikeCount;
                t.DateLastEdited = s.DateLastEdited;
                t.Category = s.Category;
                repo.AddTranslation(t);
                repo.Save();
                return RedirectToAction("Translation"); // sendir aftur i skjatextana
            }
            else
            {
                return View(s);
            }
            

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
