using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace skjatextar.Models
{
    public class Translation
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string text { get; set; }
        public DateTime DateLastEdited { get; set; }
        public string Category { get; set; }
    }
}