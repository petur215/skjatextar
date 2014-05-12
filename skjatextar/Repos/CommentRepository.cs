using skjatextar.DAL;
using skjatextar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace skjatextar.Repos
{
    public class CommentRepository
    {
        TranslationContext m_db = new TranslationContext();

        public IEnumerable<Comment> GetComments()
        {
            var result = from c in m_db.Comments
                         orderby c.TranslationID ascending
                         select c;
            return result;
        }

        public void AddComment(Comment c)
        {
            int newID = 1;
            if (m_db.Comments.Count() > 0)
            {
                newID = m_db.Comments.Max(x => x.ID) + 1;
            }
            c.ID = newID;
            c.commentDate = DateTime.Now;
            m_db.Comments.Add(c);
        }
    }
}