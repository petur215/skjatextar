using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace skjatextar.Models
{
    public class User
    {
        public int ID { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
    }

    public class skjatextar: DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}