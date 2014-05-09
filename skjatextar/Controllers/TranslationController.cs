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
            return View();
        }

        //
        // POST: /Translation/Create
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
        // GET: /Translation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Translation/Edit/5
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
        // GET: /Translation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Translation/Delete/5
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
