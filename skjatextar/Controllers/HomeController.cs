﻿using skjatextar.Models;
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
            
            result.Top10 = repo.Top10(); //nær í vinsælustu þýðingarnar í gagnagrunninn
            result.Newest10 = repo.Newest10(); //nær í nýjustu þýðingarnar í gagnagrunninn
                
            return View(result);
        }
        [HttpGet]
        public ActionResult ViewTranslation(int? id)   //  Ef ekki er slegid inn id, kemur tom sida.
        {
            if (id.HasValue)
            {
                int realid = id.Value;
                var model = repo.GetTranslationById(realid); //nær í skjátexta eftir id
                var model2 = CommentRepo.GetComments(id.Value); //nær í comment fyrir skjátextann
                string username = User.Identity.Name;

                var model3 = new TranslationAndCommentViewModel { ThisTranslation = model, ThoseComments = model2};
                return View(model3);
            }
            return View("Error");
        }
    
        public FileStreamResult DownloadTranslationSrt(int? id)//til að downloada sem .srt skrá
        {
            Translation s = repo.GetTranslationById(id.Value);

            var content = s.Text;
            var byteArray = Encoding.UTF8.GetBytes(content);
            var stream = new MemoryStream(byteArray);

            return File(stream, "text/plain", s.Title + ".srt");
        }
        public FileStreamResult DownloadTranslationTxt(int? id)//til að downloada sem .txt skrá
        {
            Translation s = repo.GetTranslationById(id.Value);

            var content = s.Text;
            var byteArray = Encoding.UTF8.GetBytes(content);
            var stream = new MemoryStream(byteArray);

            return File(stream, "text/plain", s.Title + ".txt");
        }
        [HttpGet]
        [Authorize]
        public ActionResult LikeFunction(int? id) //Like virkni
        {
            if(!repo.LikeFound(User.Identity.Name, id.Value))//er notandi búinn að like-a áður
            {
                Likes item = new Likes();
                UpdateModel(item);
                item.TranslationID = id.Value;
                item.UserName = User.Identity.Name; //heldur utan um hvaða user like-aði
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
        public ActionResult AddComment(int? id, string commentText) // Baerir vid commenti
        {                                                           // í gagnagrunn fyrir                   
            if (!User.Identity.IsAuthenticated)                     // ákveðið TranslationID
            {
                Response.StatusCode = 404;
                return Json(null, JsonRequestBehavior.DenyGet);     // Deny ef user er ekki innskráður
            }
            Comment comment = new Comment();                        // Byr til tilvik af comment og
            UpdateModel(comment);                                   // og gefur thvi rétt gildi,
            comment.CommentText = commentText;                      // addar svo í gagnagrunn
            comment.TranslationID = id.Value;                       // og skilar json
            comment.UserName = User.Identity.Name;
            comment.commentDate = DateTime.Now;
            CommentRepo.AddComment(comment);

            return Json(comment, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllComments(int id)      // Saekir oll komment i gagnagrunn fyrir akvedid TranslatioID
        {                                               // og skilar sem json streng
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