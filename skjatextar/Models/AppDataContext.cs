﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace skjatextar.Models
{
    public class AppDataContext : DbContext
    {
        public DbSet<Translation> Translations { get; set; }
        public DbSet<Categories> Category { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Likes> Likes { get; set; }
    }
}