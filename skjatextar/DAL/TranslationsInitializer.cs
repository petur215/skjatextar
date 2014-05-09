using skjatextar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace skjatextar.DAL
{
    public class TranslationsInitializer :System.Data.Entity.CreateDatabaseIfNotExists<TranslationContext>
    {
        protected override void Seed(TranslationContext context)
        {
            var translations = new List<Translation>
            {
                new Translation{
                    Title= "Batman",
                    Text= "texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Batman 2",
                    Text= "texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Spiderman",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "This is it",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Breaking bad S01E04",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Breaking bad S01E05",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Harry Potter 2",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Harry Potter 3",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Fargo",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Jango",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Friends S01E07",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Pulp Fiction",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Running with Scissors",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
            };
            translations.ForEach(s => context.Translations.Add(s));
            context.SaveChanges();
        }
    }
}