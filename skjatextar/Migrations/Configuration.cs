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
                    }
                );
            context.Categories.AddOrUpdate(
                p => p.Category,
                new Models.Categories
                {
                    ID = 1,
                    Category = "Spenna",
                },
                new Models.Categories
                {
                    ID = 2,
                    Category = "Drama",
                },
                new Models.Categories
                {
                    ID = 3,
                    Category = "Gaman",
                }
                );
            context.Comments.AddOrUpdate(
               new Models.Comment
               {
                   TranslationID = 1,
                   UserID = 1,
                   CommentText = "G�� l�sing!",
                   commentDate = DateTime.Parse("2014-05-07 16:58:00"),
               },
               new Models.Comment
               {
                   TranslationID = 2,
                   UserID = 2,
                   CommentText = "Much Comment!",
                   commentDate = DateTime.Parse("2014-05-07 16:58:00"),
               },
               new Models.Comment
               {
                   TranslationID = 3,
                   UserID = 3,
                   CommentText = "�n�g�ur me� �etta!",
                   commentDate = DateTime.Parse("2014-05-07 16:58:00"),
               }
               );
        }
    }
}
