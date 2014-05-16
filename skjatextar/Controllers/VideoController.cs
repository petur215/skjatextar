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
            var model2 = new PagedViewModel(); //býr til nýtt viewmodel sem sér um blaðsíðuskipti meðal annars
            
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            if (id != null)//ef ekkert id kemur inn í fallið er raðað eftir category
            {
                var videos = repo2.GetVideosByCategory(id.Value);
                model2.SearchResults = videos.ToPagedList(pageNumber, pageSize);
            }
            else if(LeitarStrengur != null)//ef notandi skrifaði í search bar er raðað eftir leitarstreng
            {
                model2.SearchString = LeitarStrengur;
                var videos = repo2.SearchVideos(model2.SearchString); //sendir leitarstrenginn i fallid searchvideos
                model2.SearchResults = videos.ToPagedList(pageNumber, pageSize);
            }
            else //annars er raðað eftir stafrófsröð
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
                var video = repo2.GetVideoByID(realid);  //nær í rétt video úr gagnagrunni
               
                var model = repo2.GetAllTranslationsForVideo(realid); //nær í allar þýðingar fyrir ákveðið video
                var model2 = new VideoAndTranslationViewModel { ThisVideo = video, ThoseTranslations = model }; //býr til nýtt viewmodel með ákveðnum upplýsingum
                return View(model2);
            }
            return View("Error");
        }

        [Authorize]
        public ActionResult CreateVideo()
        {
            IEnumerable<Category> model = repo2.GetAllCategories(); //nær í alla flokka úr gagnagrunni
            var model2 = new NewVideoViewModel { Categories = model }; //býr til nýtt viewmodel
            return View(model2);
        }

        [HttpPost]
        [Authorize]
        public ActionResult CreateVideo(FormCollection formData, NewVideoViewModel v)
        {
            Video model = new Video(); //býr til nýtt video
            UpdateModel(model);  //update-ar videoið með viðeigandi upplýsingum
            model.Name = v.ThisVideo.Name; //nær í titilinn sem notandi skrifaði inn og vistar
            string Category = Request.Form["ValinFlokkur"]; //nær í dropdown category sem notandi valdi
            var Flokkur = repo2.GetCategoryByName(Category); //finnur viðeigandi categoru
            model.Category = Flokkur; //stillir viðeigandi flokk á video
            model.CategoryID = Flokkur.ID; //category id vistað
            repo2.AddVideo(model); //setur videoið í gagnagrunninn
            repo2.Save();

            return RedirectToAction("LoadNewFile", "Translation");
        }
        public ActionResult Categories(int? id)//nær í öll category-in
        {
            if (id.HasValue)
            {
                var realid = id.Value;
                var cat1 = repo2.GetAllCategories();

                return View(cat1);
            }

            return View("Error");
        }
       
        private TranslationContext db = new TranslationContext();

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
