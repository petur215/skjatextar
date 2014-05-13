using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using skjatextar.Models;

namespace skjatextar.Controllers
{

    public class RequestController : Controller
    {
        RequestRepository Repoo = new RequestRepository();
        
        //
        // GET: /Request/
        public ActionResult Requests()
        {
            var requests = Repoo.GetAllRequests().Take(10);

            var newest = (from r in requests 
                         orderby r.RequestSent select r).Take(10);
            return View(newest);
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
            //RequestViewModel r = new RequestViewModel();
            //UpdateModel(r);
            Request r = new Request();
            UpdateModel(r);
            RequestRepository repo = new RequestRepository();
            repo.AddRequest(r);
            repo.Save();


            return RedirectToAction("Requests");
        }

        //GET
        [HttpPost]
        //[Authorize]
        public PartialViewResult NewRequestButton()
        {


            return PartialView();
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
