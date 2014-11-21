using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOUP_Design.Classes.Blog
{
    /// <summary>
    /// Model d'accès au données représentant un blog.
    /// </summary>
    public class Blog
    {
        /// <summary>
        /// Assigne ou récupère l'id du blog.
        /// </summary>
        public int Blog_id { get; set; }
        /// <summary>
        /// Assigne ou récupère l'id de l'utilisateur.
        /// </summary>
        public int Utilisateur_id { get; set; }
        /// <summary>
        /// Assigne ou récupère le titre du blog.
        /// </summary>
        public string TitreBlog { get; set; }
        /// <summary>
        /// Assigne ou récupère la date de création.
        /// </summary>
        public DateTime DateCreation { get; set; }
        /// <summary>
        /// Assigne ou récupère l'id de la catégorie.
        /// </summary>
        public int Categorie_id { get; set; }
        /// <summary>
        /// Assigne ou récupère si le blog est actif ou non.
        /// </summary>
        public bool Actif { get; set; }
        /// <summary>
        /// Assigne ou récupère. 
        /// </summary>
        public bool Promotion { get; set; }
        /// <summary>
        /// Assigne ou récupère l'id du thème.
        /// </summary>
        public int Theme_id { get; set; }
        public Theme Theme { get; set; }

        /// <summary>
        /// COnstructeur vide du blog.
        /// </summary>
        public Blog()
        {

        }
    }
}
