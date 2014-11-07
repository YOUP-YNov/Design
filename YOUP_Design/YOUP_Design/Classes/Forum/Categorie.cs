using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Design.Classes.Forum
{
    /// <summary>
    /// Model d'accès au données représentant la catégorie d'un forum.
    /// </summary>
    public class Categorie
    {
        /// <summary>
        /// Assigne ou récupère l'id du sujet.
        /// </summary>
        public long Sujet_id { get; set; }
        /// <summary>
        /// Assigne ou récupère l'id du forum.
        /// </summary>
        public long Forum_id { get; set; }
        /// <summary>
        /// Assigne ou récupère le nom de la catégorie.
        /// </summary>
        public string Nom { get; set; }
    }
}