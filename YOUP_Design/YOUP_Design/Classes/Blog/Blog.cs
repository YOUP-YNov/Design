using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOUP_Design.Classes.Blog
{
    public class Blog
    {
        /// <summary>
        /// 
        /// </summary>
        public int Blog_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Utilisateur_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TitreBlog { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime DateCreation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Categorie_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Actif { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Promotion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Theme_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Blog()
        {

        }
    }
}
