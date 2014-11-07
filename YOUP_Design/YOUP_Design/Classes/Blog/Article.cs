using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOUP_Design.Classes.Blog
{
    public class Article
    {
        /// <summary>
        /// 
        /// </summary>
        public int Article_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Blog_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TitreArticle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ImageChemin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ContenuArticle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Evenement_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime DateCreation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime DateModification { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Actif { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Article()
        {

        }
       
    }
}
