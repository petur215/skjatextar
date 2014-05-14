using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace skjatextar.Models
{
    public class NewVideoViewModel
    {
        public Video ThisVideo { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}