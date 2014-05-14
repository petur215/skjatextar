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
        // GET: /Translation/Default1        
        public ActionResult Videos()
        {
            var videos = repo2.GetAllVideos();
            var display = from n in videos
                          orderby n.Name
                          select n;
            return View(display);
        }
        //
        // GET: /Video/
        public ActionResult Index()
        {
            return View();
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
        //
        // GET: /Video/Create
        [Authorize]
        public ActionResult CreateVideo()
        {
            IEnumerable<Category> model = repo2.GetAllCategories();
            var model2 = new NewVideoViewModel { Categories = model };
            return View(model2);
        }

        //
        // POST: /Video/Create
        [HttpPost]
        [Authorize]
        public ActionResult CreateVideo(FormCollection formData, NewVideoViewModel v)
        {
            Video model = new Video();
            UpdateModel(model);
            model.Name = v.ThisVideo.Name;
            string Category = Request.Form["ValinFlokkur"];
            var Flokkur = repo2.GetCategoryByName(Category);
            model.Category = Flokkur;
            model.CategoryID = Flokkur.ID;
            repo2.AddVideo(model);
            repo2.Save();

            return RedirectToAction("LoadNewFile", "Translation");
        }

        [HttpGet]
        public ActionResult SearchView(string LeitarStrengur)
        {
            VideoRepository repo = new VideoRepository();
            var Videos = repo.GetAllVideos(); //Listi yfir oll video
            var search = from m in Videos
                         select m;

            if (!String.IsNullOrEmpty(LeitarStrengur)) //Ef fallid faer inn streng keyrir tetta
            {
                search = search.Where(s => s.Name.ToUpper().Contains(LeitarStrengur.ToUpper())); //Finnur allar myndir
            }                                                            //sem innihalda strenginn
            return View(search);
        }
    }
}
