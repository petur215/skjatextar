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

        public IEnumerable<Translation> GetAllTranslationsForVideo(int id)   
        {
            var result = from s in m_db.Translations
                         where s.VideoID == id
                         select s;

            return result;
        }

        // Get Video by categoryID
    }
}