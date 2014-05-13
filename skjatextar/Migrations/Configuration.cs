namespace skjatextar.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<skjatextar.DAL.TranslationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(skjatextar.DAL.TranslationContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Translations.AddOrUpdate(
                           p => p.Title,
                           new Models.Translation
                           {
                               ID = 1,
                               Title = "Batman",
                               LikeCount = 3,
                               Text = "texti texti",
                               VideoID = 1,
                               DateLastEdited = DateTime.Parse("2014-05-07 16:58:00")
                           },
                           new Models.Translation
                           {
                               ID = 2,
                               Title = "Superman",
                               LikeCount = 5,
                               Text = "texti texti",
                               VideoID = 2,
                               DateLastEdited = DateTime.Parse("2014-05-07 16:58:00")
                           },
                           new Models.Translation
                           {
                               ID = 3,
                               Title = "Superman v2",
                               LikeCount = 5,
                               Text = "texti texti",
                               VideoID = 2,
                               DateLastEdited = DateTime.Parse("2014-05-07 16:58:00")
                           },
                           new Models.Translation
                           {
                               ID = 4,
                               Title = "Harry potter 2 v1",
                               LikeCount = 1,
                               Text = "texti texti texti",
                               VideoID = 3,
                               DateLastEdited = DateTime.Parse("2014-05-07 16:58:00")
                           },
                           new Models.Translation
                           {
                               ID = 5,
                               Title = "Harry Potter 2 v3",
                               LikeCount = 41,
                               Text = "texti texti texti",
                               VideoID = 3,
                               DateLastEdited = DateTime.Parse("2014-05-07 16:58:00")
                           },
                           new Models.Translation
                           {
                               ID = 6,
                               Title = "Breaking bad S01E04",
                               LikeCount = 10,
                               Text = "texti texti texti",
                               VideoID = 4,
                               DateLastEdited = DateTime.Parse("2014-05-07 16:58:00")
                           },
                           new Models.Translation
                           {
                               ID = 7,
                               Title = "Breaking bad S01E05",
                               LikeCount = 12,
                               Text = "texti texti texti",
                               VideoID = 4,
                               DateLastEdited = DateTime.Parse("2014-05-07 16:58:00")
                           },
                           new Models.Translation
                           {
                               ID = 8,
                               Title = "Harry Potter 1 v2",
                               LikeCount = 11,
                               Text = "texti texti texti",
                               VideoID = 6,
                               DateLastEdited = DateTime.Parse("2014-05-07 16:58:00")
                           },
                           new Models.Translation
                           {
                               ID = 9,
                               Title = "Harry Potter 1 v3",
                               LikeCount = 5,
                               Text = "texti texti texti",
                               VideoID = 6,
                               DateLastEdited = DateTime.Parse("2014-05-07 16:58:00")
                           },
                           new Models.Translation
                           {
                               ID = 10,
                               Title = "Fargo",
                               LikeCount = 3,
                               Text = "texti texti texti",
                               VideoID = 7,
                               DateLastEdited = DateTime.Parse("2014-05-07 16:58:00")
                           },
                           new Models.Translation
                           {
                               ID = 11,
                               Title = "Jango",
                               LikeCount = 44,
                               Text = "texti texti texti",
                               VideoID = 8,
                               DateLastEdited = DateTime.Parse("2014-05-07 16:58:00")
                           },
                           new Models.Translation
                           {
                               ID = 12,
                               Title = "Friends S01E07",
                               LikeCount = 10,
                               Text = "texti texti texti",
                               VideoID = 9,
                               DateLastEdited = DateTime.Parse("2014-05-07 16:58:00")
                           },
                           new Models.Translation
                           {
                               ID = 13,
                               Title = "Pulp Fiction",
                               LikeCount = 1,
                               Text = "texti texti texti",
                               VideoID = 10,
                               DateLastEdited = DateTime.Parse("2014-05-07 16:58:00")
                           },
                           new Models.Translation
                           {
                               ID = 14,
                               Title = "Running with Scissors",
                               LikeCount = 5,
                               Text = "texti texti texti",
                               VideoID = 11,
                               DateLastEdited = DateTime.Parse("2014-05-07 16:58:00")
                           }
                           );
            context.Videos.AddOrUpdate(
                p => p.Name,
                    new Models.Video
                    {
                        ID = 1,
                        Name = "Batman",
                        CategoryID = 1,
                    },
                    new Models.Video
                    {
                        ID = 2,
                        Name = "Superman",
                        CategoryID = 1,
                    },
                    new Models.Video
                    {
                        ID = 3,
                        Name = "Harry Potter 2",
                        CategoryID = 3,
                    },
                    new Models.Video
                    {
                        ID = 6,
                        Name = "Harry Potter 1",
                        CategoryID = 3,
                    },
                    new Models.Video
                    {
                        ID = 4,
                        Name = "Breaking Bad",
                        CategoryID = 1,
                    },
                    new Models.Video
                    {
                        ID = 7,
                        Name = "Fargo",
                        CategoryID = 1,
                    },
                    new Models.Video
                    {
                        ID = 8,
                        Name = "Jango",
                        CategoryID = 1,
                    },
                    new Models.Video
                    {
                        ID = 9,
                        Name = "Friends",
                        CategoryID = 1,
                    },
                    new Models.Video
                    {
                        ID = 10,
                        Name = "Pulp Fiction",
                        CategoryID = 1,
                    },
                    new Models.Video
                    {
                        ID = 11,
                        Name = "Running With Scissors",
                        CategoryID = 1,
                    }
                );
            context.Categories.AddOrUpdate(
                p => p.Title,
                new Models.Category
                {
                    ID = 1,
                    Title = "Spenna",
                },
                new Models.Category
                {
                    ID = 2,
                    Title = "Drama",
                },
                new Models.Category
                {
                    ID = 3,
                    Title = "Gaman",
                }
                );
            context.Comments.AddOrUpdate(
               new Models.Comment
               {
                   TranslationID = 1,
                   //UserID = 1,
                   CommentText = "Góð lýsing!",
                   commentDate = DateTime.Parse("2014-05-07 16:58:00"),
               },
               new Models.Comment
               {
                   TranslationID = 2,
                   //UserID = 2,
                   CommentText = "Much Comment!",
                   commentDate = DateTime.Parse("2014-05-07 16:58:00"),
               },
               new Models.Comment
               {
                   TranslationID = 3,
                   //UserID = 3,
                   CommentText = "Ánægður með þetta!",
                   commentDate = DateTime.Parse("2014-05-07 16:58:00"),
               }
               );
            context.Requests.AddOrUpdate(
               new Models.Request
               {
                   ID = 1,

                   LikeCount = 2,
                   Username = "ViggiCool",
                   NewRequest = "Mig langar i Mean Girls",
                   RequestSent = DateTime.Parse("2014-05-09 16:58:00")
               },
                new Models.Request
                {
                    ID = 2,

                    LikeCount = 3,
                    Username = "PesiSvali",
                    NewRequest = "Mig langar i Shopaholic",
                    RequestSent = DateTime.Parse("2014-05-08 16:58:00")
                },
                new Models.Request
                {
                    ID = 3,

                    LikeCount = 10,
                    Username = "ToniToff",
                    NewRequest = "Nennir e-h ad gera ToyStory 2",
                    RequestSent = DateTime.Parse("2014-03-08 16:58:00")
                },
                new Models.Request
                {
                    ID = 4,

                    LikeCount = 4,
                    Username = "EinsiPungur",
                    NewRequest = "Nennir e-r ad thyda Mama Mia",
                    RequestSent = DateTime.Parse("2014-05-08 16:58:00")
                },
                new Models.Request
                {
                    ID = 5,
                    LikeCount = 6,
                    Username = "PesiIceBerg",
                    NewRequest = "Mig langar ad sja Pirates(klammyndina)",
                    RequestSent = DateTime.Parse("2014-02-08 16:58:00")
                }
                );
        }
    }
}
