using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOUP_Design.Classes.Blog
{
    /// <summary>
    /// Model d'accès au données représentant une catégorie.
    /// </summary>
    public class Theme
    {
        /// <summary>
        /// Assigne ou récupère l'id du thème.
        /// </summary>
        public int Theme_id { get; set; }
        /// <summary>
        /// Assigne ou récupère la couleur du theme.
        /// </summary>
        public string Couleur { get; set; }
        /// <summary>
        /// Assigne ou récupère le chemin de l'image du theme.
        /// </summary>
        public string ImageChemin { get; set; }
        /// <summary>
        /// COnstructeur vide de Theme.
        /// </summary>
        public Theme()
        {

        }
    }
}
