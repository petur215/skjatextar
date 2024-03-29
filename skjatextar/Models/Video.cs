﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace skjatextar.Models
{
    public class Video
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
        public int TranslationCount { get; set; }
    }
}