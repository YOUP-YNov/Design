using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOUP_Design.Classes.Blog
{
    public class Commentaire
    {
        /// <summary>
        /// 
        /// </summary>
        public int Commentaire_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Article_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Utilisateur_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ContenuCommentaire { get; set; }
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
        public Commentaire()
        {
                
        }
    }
}
