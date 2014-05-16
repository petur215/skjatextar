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
        /// Addar nyju Video object i database
        /// </summary>
        /// <param name="v">Video object tekur vid Video gognum</param>
        /// <returns>Skildar  database row id fyrir Videoid</returns>
        int AddVideo(Video v);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Translation> GetAllTranslations();

    }
}
