using skjatextar.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace skjatextar.Models
{
    public class TranslationRepository
    {
        TranslationContext m_db = new TranslationContext();

        public IEnumerable<Translation> Newest10()
        {
            var result = (from s in m_db.Translations
                          orderby s.DateLastEdited descending
                          select s).Take(10);

            return result;
        }

        /*public IEnumerable<Translation> Top10()
        {
            var result = (from s in m_db.Translations
                          orderby s.DateLastEdited descending
                          select s).Take(10);

            return result;
        }*/
    }
}