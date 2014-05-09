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
                    Title= "Batman",
                    LikeCount= 3,
                    Text= "texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Batman 2",
                    LikeCount= 5,
                    Text= "texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Spiderman",
                    LikeCount= 1,
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "This is it",
                    LikeCount= 41,
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Breaking bad S01E04",
                    LikeCount= 10,
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Breaking bad S01E05",
                    LikeCount= 12,
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Harry Potter 2",
                    LikeCount= 11,
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Harry Potter 3",
                    LikeCount= 5,
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Fargo",
                    LikeCount= 3,
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Jango",
                    LikeCount= 44,
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Friends S01E07",
                    LikeCount= 10,
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Pulp Fiction",
                    LikeCount= 1,
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
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