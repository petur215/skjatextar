using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace skjatextar.Models.ViewModel
{
    public class VideoAndTranslationViewModel
    {
        public IEnumerable<Translation> ThoseTranslations { get; set; }
        public Video ThisVideo { get; set; }
    }
}