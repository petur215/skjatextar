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
                    FileName= "Batman",
                    Text= "texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    FileName= "Batman 2",
                    Text= "texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    FileName= "Spiderman",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    FileName= "This is it",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    FileName= "Breaking bad S01E04",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    FileName= "Breaking bad S01E05",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    FileName= "Harry Potter 2",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    FileName= "Harry Potter 3",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    FileName= "Fargo",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    FileName= "Jango",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    FileName= "Friends S01E07",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    FileName= "Pulp Fiction",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    FileName= "Running with Scissors",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
            };
            translations.ForEach(s => context.Translations.Add(s));
            context.SaveChanges();
        }
    }
}