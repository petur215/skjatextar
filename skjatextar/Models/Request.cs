using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace skjatextar.Models
{
    public class Request
    {
        public int RequestID { get; set; }
        public int UserID { get; set; }
        public int LikeCount { get; set; }
        string NewRequest { get; set; }
        public DateTime RequestSent { get; set; }
    }
}