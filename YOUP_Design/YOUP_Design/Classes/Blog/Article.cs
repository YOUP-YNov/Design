using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOUP_Design.Classes.Blog
{
    /// <summary>
    /// Model d'accès au données représentant un article.
    /// </summary>
    public class Article
    {
        /// <summary>
        /// Assigne ou récupère l'id de l'article.
        /// </summary>
        public int Article_id { get; set; }
        /// <summary>
        /// Assigne ou récupère l'id du blog.
        /// </summary>
        public int Blog_id { get; set; }
        /// <summary>
        /// Assigne ou récupère le titre de l'article.
        /// </summary>
        public string TitreArticle { get; set; }
        /// <summary>
        /// Assigne ou récupère le chemin de l'image du blog.
        /// </summary>
        public string ImageChemin { get; set; }
        /// <summary>
        /// Assigne ou récupère le contenu de l'article.
        /// </summary>
        public string ContenuArticle { get; set; }
        /// <summary>
        /// Assigne ou récupère l'id de l'événement.
        /// </summary>
        public int? Evenement_id { get; set; }
        /// <summary>
        /// Assigne ou récupère la date de création.
        /// </summary>
        public DateTime DateCreation { get; set; }
        /// <summary>
        /// Assigne ou récupère la date de modification.
        /// </summary>
        public DateTime DateModification { get; set; }
        /// <summary>
        /// Assigne ou récupère si le Blog est actif ou non.
        /// </summary>
        public bool Actif { get; set; }
        /// <summary>
        /// Constructeur vide de la classe article.
        /// </summary>
        /// 
        public int? NbComments { get; set; }
         

        public List<HashTagArticles> ListTags { get; set; }
        public Article()
        {

        }
       
    }
}
