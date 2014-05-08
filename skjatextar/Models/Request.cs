using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace skjatextar.Models
{
    public class Request
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int LikeCount { get; set; }
        string Request { get; set; }
    }
}