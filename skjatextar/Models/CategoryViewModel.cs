using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace skjatextar.Models
{
    public class CategoryViewModel
    {
        public Category ThisID { get; set; }
        public IEnumerable<Category> ThisTitle { get; set; }
    }
}