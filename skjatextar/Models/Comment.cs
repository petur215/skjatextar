using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace skjatextar.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public int TranslationID { get; set; }
        public int UserID { get; set; }
        public string CommentText { get; set; }
        public DateTime commentDate { get; set; }

    }
}