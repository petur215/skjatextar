using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace skjatextar.Models
{
    public class Translation
    {
        public int ID { get; set; }
        public string FileName { get; set; }
        public string Text { get; set; }
        public DateTime DateLastEdited { get; set; }
        //public string Category { get; set; }
    }
}