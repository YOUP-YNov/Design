using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOUP_Design.Classes.Blog
{
    /// <summary>
    /// Model d'accès au données représentant commentaire.
    /// </summary>
    public class Commentaire
    {
        /// <summary>
        /// Assigne ou récupère l'id du commentaire.
        /// </summary>
        public int Commentaire_id { get; set; }
        /// <summary>
        /// Assigne ou récupère l'id de l'article.
        /// </summary>
        public int Article_id { get; set; }
        /// <summary>
        /// Assigne ou récupère l'id de l'utilisateur.
        /// </summary>
        public int Utilisateur_id { get; set; }
        /// <summary>
        /// Assigne ou récupère le contenu du commentaire.
        /// </summary>
        public string ContenuCommentaire { get; set; }
        /// <summary>
        /// Assigne ou récupère la date de création.
        /// </summary>
        public DateTime DateCreation { get; set; }
        /// <summary>
        /// Assigne ou récupère la date de modification.
        /// </summary>
        public DateTime DateModification { get; set; }
        /// <summary>
        /// Assigne ou récupère si le blog est actif ou non.
        /// </summary>
        public bool Actif { get; set; }

        /// <summary>
        /// Constructeur vide de Commentaire.
        /// </summary>
        public Commentaire()
        {
                
        }
    }
}
