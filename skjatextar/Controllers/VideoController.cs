﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace skjatextar.Controllers
{
    public class VideoController : Controller
    {
        //
        // GET: /Video/
        public ActionResult Index()
        {
            return View();
        }

        //
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
