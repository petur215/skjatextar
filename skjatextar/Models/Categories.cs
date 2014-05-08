using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace skjatextar.Models
{
    public class Categories
    {
        [Key]
        public int CategoryID { get; set; }
        public string Category { get; set; }
    }
}