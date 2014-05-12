using skjatextar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace skjatextar.Controllers
{
    public class VideoController : Controller
    {
        VideoRepository repo2 = new VideoRepository();
        // GET: /Translation/
        public ActionResult Videos()
        {
            //var translations = repo.GetAllTranslations().ToList;

            //IEnumerable<Video> newest10 = repo.Newest10();
            var videos = repo2.GetAllVideos();
            var display = from n in videos
                          orderby n.Name
                          select n;

            //return View(newest10);
            return View(display);
            //return View(translations);
        }
        //
        // GET: /Video/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SearchView(string SearchWord)
        {
            var Videos = repo2.GetAllVideos();
            var search = from m in Videos
                         select m;

            if (!String.IsNullOrEmpty(SearchWord))
            {
                search = search.Where(s => s.Name.Contains(SearchWord));
            }
            return View(search);
        }

        //
        [HttpGet]
        public ActionResult ViewVideo(int? id)   //  Ef ekki er slegid inn id, kemur tom sida.
        {
            if (id.HasValue)
            {
                int realid = id.Value;
                VideoRepository repo = new VideoRepository();
                var model = repo.GetAllTranslationsForVideo(realid);
                return View(model);
            }
            return View("Error");
        }

        // GET: /Video/Details/5
        public ActionResult VideoDetails(int id)
        {

            return View();
        }

        //
        // GET: /Video/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Video/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Video/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Video/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
