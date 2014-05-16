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
    [RequireHttps]
    public class HomeController : Controller
    {
        TranslationRepository repo = new TranslationRepository();
        CommentRepository CommentRepo = new CommentRepository();
        
        public ActionResult Index()
        {
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
                var model = repo.GetTranslationById(realid);
                var model2 = CommentRepo.GetComments(id.Value);
                string username = User.Identity.Name;

                var model3 = new TranslationAndCommentViewModel { ThisTranslation = model, ThoseComments = model2};
                return View(model3);
            }
            return View("Error");
        }
    
        public FileStreamResult DownloadTranslationSrt(int? id)
        {
            Translation s = repo.GetTranslationById(id.Value);

            var content = s.Text;
            var byteArray = Encoding.UTF8.GetBytes(content);
            var stream = new MemoryStream(byteArray);

            return File(stream, "text/plain", s.Title + ".srt");
        }
        public FileStreamResult DownloadTranslationTxt(int? id)
        {
            Translation s = repo.GetTranslationById(id.Value);

            var content = s.Text;
            var byteArray = Encoding.UTF8.GetBytes(content);
            var stream = new MemoryStream(byteArray);

            return File(stream, "text/plain", s.Title + ".txt");
        }
        [HttpGet]
        [Authorize]
        public ActionResult LikeFunction(int? id)
        {
            if(!repo.LikeFound(User.Identity.Name, id.Value))
            {
                Likes item = new Likes();
                UpdateModel(item);
                item.TranslationID = id.Value;
                item.UserName = User.Identity.Name;
                var Translation = repo.GetTranslationById(id.Value);
                Translation.LikeCount += 1;
                repo.AddLike(item);

                return RedirectToAction("ViewTranslation", new { ID = id.Value});
            }
            else
            {
                return RedirectToAction("ViewTranslation", new {ID = id.Value});
            }
        }
        public ActionResult Rules()
        {
            ViewBag.Message = "Reglur eru til þess að fara eftir þeim!";

            return View();
        }

        [HttpPost]
        public ActionResult AddComment(int? id, string commentText)
        {
            //TranslationAndCommentViewModel v = new TranslationAndCommentViewModel();
            //v.ThisComment = commentText;
            if(!User.Identity.IsAuthenticated)
            {
                Response.StatusCode = 404;
                return Json(null, JsonRequestBehavior.DenyGet);
            }
            Comment comment = new Comment();
            UpdateModel(comment);
            comment.CommentText = commentText;
            comment.TranslationID = id.Value;
            comment.UserName = User.Identity.Name;
            comment.commentDate = DateTime.Now;
            CommentRepo.AddComment(comment);

            //return RedirectToAction("ViewTranslation", new { ID = id.Value });
            return Json(comment, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllComments(int id)
        {
            var model = CommentRepository.Instance.GetComments(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult CheckUser() // Athugar hvort user se loggadur inn
        {
            if (!User.Identity.IsAuthenticated)
            {
                //Response.StatusCode = 404;
                return Json(null, JsonRequestBehavior.DenyGet);
            }
            return Json(1, JsonRequestBehavior.AllowGet);
        }
    }
}