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
        // GET: /Request/Requests
        public ActionResult Requests(int? id) // Saekir öll requests í gagnagrunn
        {                                     // raðða eftir fjölda likes
            var requests2 = Repoo.GetRequestsByLikes();

            return View(requests2);

        }

        public ActionResult RequestsByDate(int? id) // Saekir öll requests í gagnagrunn
        {                                           // raða eftir dagsetningu
            var requests = Repoo.GetAllRequests();
          

            return View("Requests", requests);
        }

        [HttpGet]
        [Authorize]
        public ActionResult LikeFunction(int? id)
        {
            if (!Repoo.LikeFound(User.Identity.Name, id.Value)) // Athugar hvort núverandi user hafi lækað áður
            {
                Likes item = new Likes();                       // Ef ekki, þá er búið til nýtt like
                UpdateModel(item);
                item.RequestID = id.Value;
                item.UserName = User.Identity.Name;
                var request = Repoo.GetRequestById(id.Value);
                request.LikeCount += 1;
                Repoo.AddLike(item);

                return RedirectToAction("Requests", new { ID = id.Value });
            }
            else
            {
                return RedirectToAction("Requests", new { ID = id.Value });
            }
        }
        [HttpGet]
        [Authorize]
        public ActionResult AddNewRequest()
        {
            return View(new RequestViewModel());
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddNewRequest(FormCollection formData)
        {
            
            Request r = new Request();          // Býr til tilvik af request
            UpdateModel(r);
            r.Username = User.Identity.Name;   // stillir user sem er loggaður inn
            RequestRepository repo = new RequestRepository();
            repo.AddRequest(r);
            repo.Save();

            return RedirectToAction("Requests");
        }
    }
}
