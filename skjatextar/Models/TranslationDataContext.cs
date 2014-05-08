using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace skjatextar.Models
{
    public class TranslationDataContext : DbContext
    {
        // ein lina fyrir hvern modelklasa
        public DbSet<User> Users { get; set; }
        // public DbSet<Request> Requests { get; set; } og svo framvegis.....
    }
}