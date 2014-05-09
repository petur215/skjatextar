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
        public int HowMany { get; set; }
        public int UserID { get; set; }

    }
}