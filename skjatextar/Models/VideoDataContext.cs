using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace skjatextar.Models
{
    public class VideoDataContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}