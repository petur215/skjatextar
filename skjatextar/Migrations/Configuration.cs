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
                    DateLastEdited = DateTime.Parse("2014-05-07 16:58:00")
                },
                new Models.Translation
                {
                    ID = 2,
                    Title = "Superman",
                    LikeCount = 5,
                    Text = "texti texti",
                    DateLastEdited = DateTime.Parse("2014-05-07 16:58:00")
                },
                new Models.Translation
                {
                    ID = 2,
                    Title = "Superman v2",
                    LikeCount = 5,
                    Text = "texti texti",
                    DateLastEdited = DateTime.Parse("2014-05-07 16:58:00")
                },
                new Models.Translation
                {
                    ID = 4,
                    Title = "Harry potter 2 v1",
                    LikeCount = 1,
                    Text = "texti texti texti",
                    DateLastEdited = DateTime.Parse("2014-05-07 16:58:00")
                },
                new Models.Translation
                {
                    ID = 4,
                    Title = "Harry Potter 2 v3",
                    LikeCount = 41,
                    Text = "texti texti texti",
                    DateLastEdited = DateTime.Parse("2014-05-07 16:58:00")
                },
                new Models.Translation
                {
                    ID = 5,
                    Title = "Breaking bad S01E04",
                    LikeCount = 10,
                    Text = "texti texti texti",
                    DateLastEdited = DateTime.Parse("2014-05-07 16:58:00")
                },
                new Models.Translation
                {
                    ID = 6,
                    Title = "Breaking bad S01E05",
                    LikeCount = 12,
                    Text = "texti texti texti",
                    DateLastEdited = DateTime.Parse("2014-05-07 16:58:00")
                },
                new Models.Translation
                {
                    ID = 3,
                    Title = "Harry Potter 1 v2",
                    LikeCount = 11,
                    Text = "texti texti texti",
                    DateLastEdited = DateTime.Parse("2014-05-07 16:58:00")
                },
                new Models.Translation
                {
                    ID = 3,
                    Title = "Harry Potter 1 v3",
                    LikeCount = 5,
                    Text = "texti texti texti",
                    DateLastEdited = DateTime.Parse("2014-05-07 16:58:00")
                },
                new Models.Translation
                {
                    ID = 7,
                    Title = "Fargo",
                    LikeCount = 3,
                    Text = "texti texti texti",
                    DateLastEdited = DateTime.Parse("2014-05-07 16:58:00")
                },
                new Models.Translation
                {
                    ID = 8,
                    Title = "Jango",
                    LikeCount = 44,
                    Text = "texti texti texti",
                    DateLastEdited = DateTime.Parse("2014-05-07 16:58:00")
                },
                new Models.Translation
                {
                    ID = 9,
                    Title = "Friends S01E07",
                    LikeCount = 10,
                    Text = "texti texti texti",
                    DateLastEdited = DateTime.Parse("2014-05-07 16:58:00")
                },
                new Models.Translation
                {
                    ID = 10,
                    Title = "Pulp Fiction",
                    LikeCount = 1,
                    Text = "texti texti texti",
                    DateLastEdited = DateTime.Parse("2014-05-07 16:58:00")
                },
                new Models.Translation
                {
                    ID = 11,
                    Title = "Running with Scissors",
                    LikeCount = 5,
                    Text = "texti texti texti",
                    DateLastEdited = DateTime.Parse("2014-05-07 16:58:00")
                }
                );
        }
    }
}
