using skjatextar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using skjatextar.DAL;
using PagedList;
using skjatextar.Models.ViewModel;

namespace skjatextar.Controllers
{
    public class VideoController : Controller
    {
        VideoRepository repo2 = new VideoRepository();
        // GET: /Translation/Default1    
        public ActionResult Videos(int? id, int? page, string LeitarStrengur)
        {
            var model2 = new PagedViewModel();
            
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            int pageSize = 2;
            int pageNumber = (page ?? 1);

            if (id != null)
            {
                var videos = repo2.GetVideosByCategory(id.Value);
                model2.SearchResults = videos.ToPagedList(pageNumber, pageSize);
            }
            else if(LeitarStrengur != null)
            {
                model2.SearchString = LeitarStrengur;
                var videos = repo2.SearchVideos(model2.SearchString); //sendir leitarstrenginn i fallid searchvideos
                model2.SearchResults = videos.ToPagedList(pageNumber, pageSize);
            }
            else
            {
                var videos = db.Videos.Include(v => v.Category).OrderBy(s => s.Name);
                model2.SearchResults = videos.ToPagedList(pageNumber, pageSize);
            }

            model2.ThoseCategories = repo2.GetAllCategories();
            return View("Videos", model2);
        }
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
        public ActionResult CreateVideo(FormCollection formData, NewVideoViewModel v, object sender, EventArgs e)
        {
            Video model = new Video();
            UpdateModel(model);
            model.Name = v.ThisVideo.Name;
            string Category = Request.Form["ValinFlokkur"];
            var Flokkur = repo2.GetCategoryByName(Category);
            //bool isChecked = DeafCheck.Checked;
            //if(isChecked)
            model.Category = Flokkur;
            model.CategoryID = Flokkur.ID;
            repo2.AddVideo(model);
            repo2.Save();

            return RedirectToAction("LoadNewFile", "Translation");
        }
        public ActionResult Categories(int? id)
        {
            if(id.HasValue)
            {
                var realid = id.Value;
                var cat = repo2.GetVideosByCategory(realid);
                var cat1 = repo2.GetAllCategories();
                //var cat2 = new CategoryViewModel { ThoseVideos = cat, ThoseCategories = cat1 };
                return View(cat1);
            }
            
            return View("Error");
        }
       
        private TranslationContext db = new TranslationContext();

        // GET: /Style/
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
