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

namespace skjatextar.Controllers
{
    public class HomeController : Controller
    {
        TranslationRepository repo = new TranslationRepository();
        
        public ActionResult Index()
        {
            //var newest10 = repo.GetAllTranslations().Take(10).ToList(); // skilar nyjustu 10 þýðingunum
            //return View(newest10);
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
                TranslationRepository repo3 = new TranslationRepository();
                CommentRepository commentRepo = new CommentRepository();
                var model = repo3.GetTranslationById(realid);
                //var model = commentRepo.GetComments(); ???

                return View(model);
            }
            return View("Error");
        }

        [HttpPost]
        public void ViewTranslation(int id, object sender, EventArgs e, FormCollection formData)
        {
            Translation s = repo.GetTranslationById(id);
            // Write the string to a file.
            StreamWriter file = new StreamWriter("c:/Users/Petur/Documents/prufa/test.srt");
            file.WriteLine(s.Text);
            file.Close();
            /*string filePath = lblFilename.Text;

            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
            Response.TransmitFile(Server.MapPath(filePath));
            Response.End();*/

            String strComment = formData["CommentText"];
            if (!String.IsNullOrEmpty(strComment))
            {
                Comment c = new Comment();

                c.CommentText = strComment;
                String strUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                if (!String.IsNullOrEmpty(strUser))
                {
                    int slashPos = strUser.IndexOf("\\");
                    if (slashPos != -1)
                    {
                        strUser = strUser.Substring(slashPos + 1);
                    }
                    //c.Username = strUser;

                    CommentRepository commentRepo = new CommentRepository();
                    commentRepo.AddComment(c);
                }
                else
                {
                    //c.Username = "Unknown user";
                }
            }
            else
            {
                ModelState.AddModelError("CommentText", "Comment text cannot be empty!");
            }
        }

        public ActionResult Requests()
        {
            ViewBag.Message = "trolololololol";

            return View();
        }
        public ActionResult Rules()
        {
            ViewBag.Message = "Reglur eru til þess að fara eftir þeim!";

            return View();
        }

        public ViewResult About()
        {
            throw new NotImplementedException();
        }

        public ViewResult Contact()
        {
            throw new NotImplementedException();
        }
    }
}