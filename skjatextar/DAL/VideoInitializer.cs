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
                   ID= 1,
                    Name= "Batman",
                },
                new Video{
                    ID= 2,
                    Name= "Superman",
                },
                new Video{
                    ID= 3,
                    Name= "Harry potter 1",
                },
                new Video{
                    ID= 4,
                    Name= "Harry potter 2",
                },

            };
            videos.ForEach(s => context.Videos.Add(s));
            context.SaveChanges();
        }
    }
}