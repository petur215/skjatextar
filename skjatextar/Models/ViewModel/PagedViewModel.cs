using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace skjatextar.Models.ViewModel
{
    public class PagedViewModel
    {
        public IPagedList<Video> SearchResults { get; set; }
        public IEnumerable<Category> ThoseCategories { get; set; }
        public string SearchString { get; set; }
    }
}