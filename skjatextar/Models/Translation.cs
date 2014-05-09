using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace skjatextar.Models
{
    public class Translation : Video
    {
        public int ID { get; set; }
        public int VideoID { get; set; }
        public string TranslationTitle { get; set; }
        public int LikeCount { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
        public DateTime DateLastEdited { get; set; }
    }
}