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
            
            foreach(var i in requests)
            {
                i.LikeCount = Repoo.CountAllLikes(i.ID);
            }

            return View(requests);

        }

        [HttpGet]
        public ActionResult LikeFunction(int? id)
        {
            if (!Repoo.LikeFound(User.Identity.Name, id.Value))
            {
                Likes item = new Likes();
                UpdateModel(item);
                item.RequestID = id.Value;
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
    }
}
