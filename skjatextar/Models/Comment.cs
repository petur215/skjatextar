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
        string CommentText { get; set; }

    }
}