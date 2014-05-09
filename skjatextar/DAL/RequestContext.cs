using skjatextar.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace skjatextar.DAL
{
    public class RequestContext : DbContext
    {
        public RequestContext()
            : base("RequestContext")
        {

        }

        public DbSet<Request> Requests{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}