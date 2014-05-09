using skjatextar.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace skjatextar.Models
{
    public class TranslationRepository
    {
        TranslationContext m_db = new TranslationContext();

        public IEnumerable<Translation> Newest10()
        {
            var result = (from s in m_db.Translations
                          orderby s.DateLastEdited descending
                          select s).Take(10);

            return result;
        }
        public Translation GetNewsById(int id)
        {
            var result = (from s in m_db.Translations
                          where s.ID == id
                          select s).SingleOrDefault();

            return result;
        }
        public void AddTranslation(Translation s)
        {
            m_db.Translations.Add(s);
            m_db.SaveChanges();
        }
        public void Save()
        {
            m_db.SaveChanges();
        }
        public void UpdateNews(Translation s)
        {
            Translation t = GetNewsById(s.ID);
            if (t != null)
            {
                t.Title = s.Title;
                t.Text = s.Text;
                t.Category = s.Category;
                m_db.SaveChanges();
            }
        }
        /*public IEnumerable<Translation> Top10()
        {
            var result = (from s in m_db.Translations
                          orderby s.DateLastEdited descending
                          select s).Take(10);

            return result;
        }*/
    }
}