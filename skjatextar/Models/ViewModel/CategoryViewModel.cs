using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace skjatextar.Models
{
    public class CategoryViewModel
    {
        public IEnumerable<Video> ThoseVideos  { get; set;}
        public IEnumerable<Category> ThoseCategories { get; set; }

    }
}