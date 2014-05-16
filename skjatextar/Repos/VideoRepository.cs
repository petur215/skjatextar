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
        public IEnumerable<Category> GetAllCategories()
        {
            var result = from s in m_db.Categories
                             orderby s.Title ascending
                             select s;
            return result;
        }
        public Category GetCategoryByName(string name)
        {
            var result = (from s in m_db.Categories
                          where s.Title == name
                          select s).FirstOrDefault();
            return result;
        }

        public IEnumerable<Video> GetVideosByCategory(int id)
        {
            var videos = (from s in m_db.Videos
                         where s.CategoryID == id
                         orderby s.Name ascending
                         select s).ToList();

            return videos;
        }

        public IEnumerable<Video> SearchVideos(string LeitarStrengur)
        {
            var search = (from m in m_db.Videos                                         //Finnur allt myndefni sem 
                          where m.Name.ToLower().Contains(LeitarStrengur.ToLower())     //inniheldur leitarstrenginn
                          select m).ToList();

            return search;
        }

        public IEnumerable<Translation> GetAllTranslationsForVideo(int id)   
        {
            var result = from s in m_db.Translations
                         where s.VideoID == id 
                         orderby s.LikeCount descending
                         select s;

            return result;
        }
        public Video GetVideoByID(int id)
        {
            var result = (from s in m_db.Videos
                          where s.ID == id
                          select s).FirstOrDefault();
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
        public int AddVideo(Video v)
        {
            this.m_db.Videos.Add(v);
            this.m_db.SaveChanges();
            return v.ID;
        }
          public void Save()
        {
            m_db.SaveChanges();
        }
    }
}