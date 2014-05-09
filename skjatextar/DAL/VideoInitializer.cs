using skjatextar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace skjatextar.DAL
{
    public class VideoInitializer :System.Data.Entity.DropCreateDatabaseIfModelChanges<TranslationContext>
    {
        protected override void Seed(TranslationContext context)
        {
            var videos = new List<Video>
            {
                new Video{
                    VideoID= 1,
                    Name= "Batman",
                },
                new Video{
                    VideoID= 2,
                    Name= "Superman",
                },
                new Video{
                    VideoID= 3,
                    Name= "Harry potter 1",
                },
                new Video{
                    VideoID= 4,
                    Name= "Harry potter 2",
                },

            };
            videos.ForEach(s => context.Videos.Add(s));
            context.SaveChanges();
        }
    }
}