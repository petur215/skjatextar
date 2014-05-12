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

        public Video GetVideoById(int id)   // Tharf ad breyta thessu i GetAllTranslationsForThisVideoID
        {
            var result = (from s in m_db.Videos
                         where s.ID == id
                         select s).First();

            return result;
        }

        // Get Video by categoryID
    }
}