using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Design.Classes.Forum
{
    public class Topic
    {
        /// <summary>
        /// Assigne ou récupère l'id du topic.
        /// </summary>
        public long Topic_id { get; set; }
        /// <summary>
        /// Assigne ou récupère l'id du sujet.
        /// </summary>
        public long Sujet_id { get; set; }
        /// <summary>
        /// Assigne ou récupère le nom du topic.
        /// </summary>
        public string Nom { get; set; }
        /// <summary>
        /// Assigne ou récupère le descriptif du topic.
        /// </summary>
        public string DescriptifTopic { get; set; }
        /// <summary>
        /// Assigne ou récupère la date de création du topic.
        /// </summary>
        public System.DateTime DateCreation { get; set; }
        /// <summary>
        /// Assigne ou récupère le fait que le topic soit résolu ou non.
        /// </summary>
        public bool Resolu { get; set; }
        /// <summary>
        /// Assigne ou récupère l'id de l'utilisateur.
        /// </summary>
        public long Utilisateur_id { get; set; }

    }
}