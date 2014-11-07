using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Design.Classes.Forum
{
    /// <summary>
    /// Model d'accès au données représentant un forum.
    /// </summary>
    public class Forum
    {
        /// <summary>
        /// Assigne ou récupère l'id du forum.
        /// </summary>
        public long Forum_id { get; set; }
        /// <summary>
        /// Assigne ou récupère le nom.
        /// </summary>
        public string Nom { get; set; }
        /// <summary>
        /// Assigne ou récupère l'url du forum.
        /// </summary>
        public string Url { get; set; }
    }
}