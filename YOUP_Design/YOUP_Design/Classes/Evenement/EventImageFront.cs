using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOUP_Design.Classes.Evenement
{
    /// <summary>
    /// Model d'accès au données représentant l'image d'un événement.
    /// </summary>
    public class EventImageFront
    {
        /// <summary>
        /// Assigne ou récupère l'url de l'image.
        /// </summary>
        public String Url { get; set; }

        /// <summary>
        /// Assigne ou récupère l'id de l'image.
        /// </summary>
        public long Id { get; set; }
    }
}
