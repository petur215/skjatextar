using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace skjatextar.Models
{
    public class RequestViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage="Username is required")]
        public string Username { get; set; }
        public int LikeCount { get; set; }

        [Required(ErrorMessage="Text is required")]
        public string NewRequest { get; set; }
        public DateTime RequestSent { get; set; }
        public RequestViewModel()
        {
            RequestSent = DateTime.Now;
        }
    }
}