﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace skjatextar.Models
{
    public class TranslationDataContext : DbContext
    {
        public DbSet<Translation> Translations { get; set; }
    }
}