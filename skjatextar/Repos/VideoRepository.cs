using skjatextar.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace skjatextar.Models
{
    public class VideoRepository
    {
        TranslationContext m_db = new TranslationContext();

        public IEnumerable<Video> GetAllVideos()
        {
            var videos = from s in m_db.Videos
                         orderby s.Name ascending
                         select s;
            return videos;
        }

        public IEnumerable<Video> GetVideosByCategory(int id)
        {
            var videos = from s in m_db.Videos
                         where s.CategoryID == id
                         orderby s.Name ascending
                         select s;

            return videos;
        }

        public IEnumerable<Translation> GetAllTranslationsForVideo(int id)   
        {
            var result = from s in m_db.Translations
                         where s.VideoID == id 
                         orderby s.LikeCount descending
                         select s;

            return result;
        }
        public IEnumerable<Translation> GetAllTranslationsForVideoByDate(int id)
        {
            var result = from s in m_db.Translations
                         where s.VideoID == id
                         orderby s.DateLastEdited descending
                         select s;

            return result;
        }
        public Video GetVideoByName(string name)
        {
            var result = (from s in m_db.Videos
                         where s.Name == name
                         select s).FirstOrDefault();
            return result;
        }

        public int addCategory(Category cat)
        {
            this.m_db.Categories.Add(cat);
            this.m_db.SaveChanges();
            return cat.ID;
        }

        // Get Video by categoryID

        public int VideoCount()
        {
            int count = (from s in m_db.Videos
                         select s).Count();
            return count;
        }
    }
}