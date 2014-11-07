using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOUP_Design.Classes.Blog
{
    public class Publicite
    {
        /// <summary>
        /// 
        /// </summary>
        public int Publicite_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Blog_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Largeur { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Hauteur { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ContenuPublicite { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Publicite()
        {

        }
    }
}
