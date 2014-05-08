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
                    Text= "texti texti",
                    Category= "Spenna",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Superman",
                    Text= "texti texti",
                    Category= "Spenna",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Die Hard",
                    Text= "texti texti texti",
                    Category= "Spenna",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Lord of the Rings 1",
                    Text= "texti texti texti",
                    Category= "Gaman",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Lord of the Rings 2",
                    Text= "texti texti texti",
                    Category= "Gaman",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Lord of the Rings 3",
                    Text= "texti texti texti",
                    Category= "Gaman",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "This is the end",
                    Text= "texti texti texti",
                    Category= "Gaman",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "The Hobbit",
                    Text= "texti texti texti",
                    Category= "Gaman",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Fargo",
                    Text= "texti texti texti",
                    Category= "Gaman",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Avangers",
                    Text= "texti texti texti",
                    Category= "Gaman",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Peter Pan",
                    Text= "texti texti texti",
                    Category= "Gaman",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Harry Potter 1",
                    Text= "texti texti texti",
                    Category= "Gaman",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
                new Translation{
                    Title= "Harry Potter 2",
                    Text= "texti texti texti",
                    Category= "Gaman",
                    DateLastEdited= DateTime.Parse("2014-05-07 16:58:00")
                },
            };
            translations.ForEach(s => context.Translations.Add(s));
            context.SaveChanges();
        }
    }
}