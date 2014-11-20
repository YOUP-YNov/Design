using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Design.Classes.Forum
{
    /// <summary>
    /// Model d'accès au données représentant le message d'un forum.
    /// </summary>
    public class Message
    {

        public Message()
        {   }
        /// <summary>
        /// Assigne ou récupère l'id du message.
        /// </summary>
        public long Message_id { get; set; }
        /// <summary>
        /// Assigne ou récupère l'id du topic.
        /// </summary>
        public long Topic_id { get; set; }
        /// <summary>
        /// Assigne ou récupère l'id de l'utilisateur.
        /// </summary>
        public long Utilisateur_id { get; set; }
        /// <summary>
        /// Assigne ou récupère la date du post.
        /// </summary>
        public System.DateTime DatePoste { get; set; }
        /// <summary>
        /// Assigne ou récupère le contenu du message.
        /// </summary>
        public string ContenuMessage { get; set; }
    }
}