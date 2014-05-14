using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using skjatextar.Models;
using skjatextar.Repos;

namespace skjatextar.Controllers
{

    public class RequestController : Controller
    {
        RequestRepository Repoo = new RequestRepository();
        
        //
        // GET: /Request/
        public ActionResult Requests(int? id)
        {
            var requests = Repoo.GetAllRequests();

            var newest = from r in requests
                         orderby r.RequestSent descending
                         select r;

            return View(newest);

        }

        [HttpGet]
        public ActionResult LikeFunction(int? id)
        {
            if (!Repoo.LikeFound(User.Identity.Name, id.Value))
            {
                Likes item = new Likes();
                UpdateModel(item);
                item.TranslationID = id.Value;
                item.UserName = User.Identity.Name;
                Repoo.AddLike(item);

                return RedirectToAction("Requests", new { ID = id.Value });
            }
            else
            {
                return RedirectToAction("Requests", new { ID = id.Value });
            }
        }



        [HttpGet]
        public ActionResult AddNewRequest()
        {
            return View(new RequestViewModel());
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddNewRequest(FormCollection formData)
        {
            
            Request r = new Request();
            UpdateModel(r);
            r.Username = User.Identity.Name;
            RequestRepository repo = new RequestRepository();
            repo.AddRequest(r);
            repo.Save();


            return RedirectToAction("Requests");
        }

       


        //
        // GET: /Request/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Request/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Request/Create
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
        // GET: /Request/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Request/Edit/5
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

        //
        // GET: /Request/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Request/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
