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
                    TranslationTitle= "Batman",
                    Text= "texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    TranslationTitle= "Batman 2",
                    Text= "texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    TranslationTitle= "Spiderman",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    TranslationTitle= "This is it",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    TranslationTitle= "Breaking bad S01E04",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    TranslationTitle= "Breaking bad S01E05",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    TranslationTitle= "Harry Potter 2",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    TranslationTitle= "Harry Potter 3",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    TranslationTitle= "Fargo",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    TranslationTitle= "Jango",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    TranslationTitle= "Friends S01E07",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    TranslationTitle= "Pulp Fiction",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    TranslationTitle= "Running with Scissors",
                    Text= "texti texti texti",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
            };
            translations.ForEach(s => context.Translations.Add(s));
            context.SaveChanges();
        }
    }
}