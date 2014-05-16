using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using skjatextar.DAL;

namespace skjatextar.Models
{
    public class RequestRepository
    {
        TranslationContext m_db = new TranslationContext();

        public Request GetRequestById(int id)
        {
            var result = (from s in m_db.Requests
                          where s.ID == id
                          select s).SingleOrDefault();

            return result;
        }

        public IEnumerable<Request> GetAllRequests()
        {
            var requests = (from r in m_db.Requests
                            orderby r.RequestSent descending
                            select r).ToList();

            return requests;
        }

        public IEnumerable<Request> GetRequestsByLikes()
        {
            var requests =  (from r in m_db.Requests
                            orderby r.LikeCount descending
                            select r).ToList();

            return requests;
        }

        public void AddRequest(Request s)
        {
            m_db.Requests.Add(s);
            m_db.SaveChanges();
        }

        public void AddLike(Likes s)
        {
            m_db.Likes.Add(s);
            Save();
        }

        public int CountAllLikes(int id)
        {
            var result = (from s in m_db.Likes
                          where s.RequestID == id
                          select s).Count();
            return result;
        }

        public bool LikeFound(string User, int id)
        {
            var result = (from s in m_db.Likes
                          where s.RequestID == id && s.UserName == User
                          select s).FirstOrDefault();
            if (result != null)
            {
                return true;
            }
            else { return false; }
        }

        public void Save()
        {
            m_db.SaveChanges();
        }
    }
}