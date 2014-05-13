using skjatextar.DAL;
using skjatextar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace skjatextar.Repos
{
    public class LikeRepository
    {

        TranslationContext m_db = new TranslationContext();

        public  IEnumerable<Likes> GetLikesById(int id)
        {
            var result = from s in m_db.Likes
                          where s.ID == id
                          select s;

            return result;
        }

        //public Likes CheckLike(int id)
        //{
        //    var result = (from c in m_db.Likes
        //                  where c. == id
        //                  select c).FirstOrDefault();

        //    return result;
        //}

        public void AddLike(Likes c)
        {
            int newID = 1;
            if(m_db.Likes.Count() > 0)
            {

            }
        }
    }
}