using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace YOUP_Design.Models.Forum
{
    public class MessageModel
    {

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
        [Required(ErrorMessage = "Le message ne peut être nul")]
        [Display(Name = "Contenu du message")]
        public string ContenuMessage { get; set; }

    }
}