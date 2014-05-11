using skjatextar.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace skjatextar.DAL
{
    public class TranslationContext : DbContext
    {
        
        public TranslationContext()
            : base("DefaultConnection")
        {
            

        }
        public DbSet<Translation> Translations { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Likes> Likes { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<User> Users { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
       // }
    }
}