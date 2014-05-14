using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace skjatextar.Models
{
    public class TranslationAndCommentViewModel
    {
        public Translation ThisTranslation { get; set; }
        public IEnumerable<Comment> ThoseComments { get; set; }
        public Comment ThisComment { get; set; }
 
    }
}