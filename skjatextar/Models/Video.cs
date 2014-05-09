using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace skjatextar.Models
{
    public class Video : Categories
    {
        public int VideoID { get; set; }
        public string Name { get; set; }
    }
}