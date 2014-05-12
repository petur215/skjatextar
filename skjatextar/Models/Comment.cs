using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace skjatextar.Models
{
    public class Comment
    {
        public int ID { get; set; }

        public int? UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        public int? TranslationID { get; set; }
        [ForeignKey("TranslationID")]
        public virtual Translation Translation { get; set; }

        public string CommentText { get; set; }
        public DateTime commentDate { get; set; }
        public Comment()
        {
            commentDate = DateTime.Now;
        }

    }
}