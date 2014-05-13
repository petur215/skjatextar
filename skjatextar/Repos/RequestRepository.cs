﻿using System;
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
            var requests = from r in m_db.Requests
                           orderby r.RequestSent  ascending
                           select r;

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

        public void Save()
        {
            m_db.SaveChanges();
        }

       

    }
}