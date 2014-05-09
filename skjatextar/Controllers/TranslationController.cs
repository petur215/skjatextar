using skjatextar.Models;
using System;
using System.Collections.Generic;
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
            IEnumerable<Translation> newest10 = repo.Newest10();

            return View(newest10);
        }

        //
        // GET: /Translation/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        //
        // GET: /Translation/Create
        public ActionResult Create()
        {
            return View(new Translation());
        }

        //
        // POST: /Translation/Create
        [HttpPost]
        public ActionResult Create(FormCollection formData)
        {
            Translation item = new Translation(); //býr til nýtt item

            //item.VideoConnection = Video.VideoID;
            item.Title = formData["Title"];
            item.Text = formData["Text"];
            item.Category = formData["Category"]; //category harðkóðað samkvæmt verkefnalýsingu
            item.DateLastEdited = DateTime.Now;

            if ((item.Title == "") || (item.Text == "")) //ef titill eða texti er tómt þá ferðu á Error síðu
            {
                return View("Error");
            }
            UpdateModel(item);
            repo.AddTranslation(item);

            repo.Save();
            return RedirectToAction("Translations");//þegar ýtt er á save ferðu aftur á forsíðu
            
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
            repo.UpdateNews(item);

            repo.Save();
            return RedirectToAction("Edit");
        }
    }
}
