using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace skjatextar.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Translation> Top10 { get; set; }
        public IEnumerable<Translation> Newest10 { get; set; }
    }
}