using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skjatextar.Models
{
    public interface ITranslationRepository
    {
        /// <summary>
        /// Adds new Video object to currently selected datastore.
        /// </summary>
        /// <param name="v">Video object filled with Video informations</param>
        /// <returns>Returns the database row id for the newly inserted Video.</returns>
        int AddVideo(Video v);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Translation> Newest10();

    }
}
