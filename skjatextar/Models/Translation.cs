using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace skjatextar.Models
{
    public class Translation
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int LikeCount { get; set; }
        public string Text { get; set; }
        public int? VideoID { get; set; }
        [ForeignKey("VideoID")]
        public virtual Video Video { get; set; }
        public string DeafCheck { get; set; }
        public DateTime DateLastEdited { get; set; }
        public Translation()
        {
            DateLastEdited = DateTime.Now;
        }
    }
}