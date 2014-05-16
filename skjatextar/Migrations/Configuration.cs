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
               },
                new Models.Category
                {
                    ID = 4,
                    Title = "Hasar",
                },
                new Models.Category
                {
                    ID = 5,
                    Title = "Hrollvekja",
                },
                new Models.Category
                {
                    ID = 6,
                    Title = "Barnaefni",
                },
                new Models.Category
                {
                    ID = 7,
                    Title = "Ævintýri",
                }
               );
        }
    }
}
