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
        /// <returns>Skildar database row id fyrir Videoid</returns>
        int AddVideo(Video v);

        /// <summary>
        /// Saekir allar thydingar i database
        /// </summary>
        /// <returns>Skilar ollum thydingum ur database, radad eftir ID</returns>
        IEnumerable<Translation> GetAllTranslations();

        /// <summary>
        /// Teka saman lista fyrir forsiduna
        /// </summary>
        /// <returns>Skila nyjustu og vinsaelustu thydingunum</returns>
        IEnumerable<Translation> Top10();
        IEnumerable<Translation> Newest10();

        /// <summary>
        /// Saekir thydingu fyrir akvedid ID i database
        /// </summary>
        /// <returns>Skilar thydingu fyrir akvedid ID</returns>
        Translation GetTranslationById(int id);

        /// <summary>
        /// Addar Translation i database
        /// </summary>
        void AddTranslation(Translation s);

        /// <summary>
        /// Addar like i database
        /// </summary>
        void AddLike(Likes s);

        /// <summary>
        /// Athugar hvort akvedinn User hefur like-ad akvedna thydingu
        /// </summary>
        /// <returns>Skilar true ef skilirdi er uppfyllt, annars false</returns>
        bool LikeFound(string User, int id);

        /// <summary>
        /// Tekur vid thidingu object s, finnur thydingu med sama ID
        /// og uppfaerir titil og texta fra s.
        /// </summary>
        void UpdateTranslation(Translation s);

    }
}
