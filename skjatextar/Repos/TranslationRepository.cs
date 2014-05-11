using skjatextar.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace skjatextar.Models
{
    public class TranslationRepository : ITranslationRepository
    {
        TranslationContext m_db = new TranslationContext();

        public IEnumerable<Translation> Newest10()
        {
            var result = (from s in m_db.Translations
                          orderby s.DateLastEdited descending
                          select s).Take(10);

            return result;
        }

        public IEnumerable<Translation> Top10()
        {
            var result = (from s in m_db.Translations
                          orderby s.LikeCount descending
                          select s).Take(10);

            return result;
        }

        public IEnumerable<Translation> GetTranslationByVideoID(int id)
        {
            //var result = (from s in m_db.Translations
            //              where s.VideoID == id
            //              select s).Take(10);
            //return result;
            throw new NotImplementedException();
        }
        
        public Translation GetTranslationById(int id)
        {
            var result = (from s in m_db.Translations
                          where s.ID == id
                          select s).First();

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

        public void UpdateTranslation(Translation s)
        {
            Translation t = GetTranslationById(s.ID);
            if (t != null)
            {
                t.Title = s.Title;
                t.Text = s.Text;
                t.Category = s.Category;
                m_db.SaveChanges();
            }
        }

        public int AddVideo(Video v)
        {
            this.m_db.Videos.Add(v);
            this.m_db.SaveChanges();
            return v.VideoID;
        }
    }
}