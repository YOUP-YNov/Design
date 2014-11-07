using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOUP_Design.Classes.Blog
{
    public class Publicite
    {
        /// <summary>
        /// Assigne ou récupère l'id de la publicité.
        /// </summary>
        public int Publicite_id { get; set; }
        /// <summary>
        /// Assigne ou récupère l'id du blog.
        /// </summary>
        public int Blog_id { get; set; }
        /// <summary>
        /// Assigne ou récupère la largeur de la publicité.
        /// </summary>
        public int Largeur { get; set; }
        /// <summary>
        /// Assigne ou récupère la hauteur de la publicité.
        /// </summary>
        public int Hauteur { get; set; }
        /// <summary>
        /// Assigne ou récupère le contenu de la publicité.
        /// </summary>
        public string ContenuPublicite { get; set; }

        /// <summary>
        /// Constructeur vide de Publicite.
        /// </summary>
        public Publicite()
        {

        }
    }
}
