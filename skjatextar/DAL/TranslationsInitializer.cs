using skjatextar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace skjatextar.DAL
{
    public class TranslationsInitializer :System.Data.Entity.DropCreateDatabaseIfModelChanges<TranslationContext>
    {
        protected override void Seed(TranslationContext context)
        {
            var translations = new List<Translation>
            {
                new Translation{
                    ID= 1,
                    Title= "Batman",
                    LikeCount= 3,
                    Text= "texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    ID= 2,
                    Title= "Superman",
                    LikeCount= 5,
                    Text= "texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    ID= 2,
                    Title= "Superman v2",
                    LikeCount= 5,
                    Text= "texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    ID= 4,
                    Title= "Harry potter 2 v1",
                    LikeCount= 1,
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    ID= 4,
                    Title= "Harry Potter 2 v3",
                    LikeCount= 41,
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    ID= 5,
                    Title= "Breaking bad S01E04",
                    LikeCount= 10,
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    ID= 6,
                    Title= "Breaking bad S01E05",
                    LikeCount= 12,
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    ID= 3,
                    Title= "Harry Potter 1 v2",
                    LikeCount= 11,
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    ID= 3,
                    Title= "Harry Potter 1 v3",
                    LikeCount= 5,
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    ID= 7,
                    Title= "Fargo",
                    LikeCount= 3,
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    ID= 8,
                    Title= "Jango",
                    LikeCount= 44,
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    ID= 9,
                    Title= "Friends S01E07",
                    LikeCount= 10,
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    ID= 10,
                    Title= "Pulp Fiction",
                    LikeCount= 1,
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    ID= 11,
                    Title= "Running with Scissors",
                    LikeCount= 5,
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
            };
            translations.ForEach(s => context.Translations.Add(s));
            context.SaveChanges();
        }
    }
}