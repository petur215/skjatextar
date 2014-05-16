using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace skjatextar.Models
{
    public class Request
    {
        public int ID { get; set; }
        public string Username { get; set; }

        public int LikeCount { get; set; }
        public string NewRequest { get; set; }
        public DateTime RequestSent { get; set; }
        public Request()
        {
            RequestSent = DateTime.Now;
        }
    }
}