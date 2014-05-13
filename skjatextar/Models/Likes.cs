using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace skjatextar.Models
{
    public class Likes
    {
        public int ID { get; set; }
        public int TranslationID { get; set; }
        public int RequestID { get; set; }
        public string UserName { get; set; }

    }
}