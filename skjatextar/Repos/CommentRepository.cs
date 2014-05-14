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
        public IEnumerable<Comment> GetComments(int id)
        {
            var result = (from c in m_db.Comments
                          where c.TranslationID == id
                          orderby c.commentDate ascending
                          select c).ToList();

            return result;
        }

        public void AddComment(Comment c)
        {
            m_db.Comments.Add(c);
            m_db.SaveChanges();
        }
    }
}