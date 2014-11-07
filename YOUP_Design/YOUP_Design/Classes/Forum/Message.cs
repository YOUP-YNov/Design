using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Design.Classes.Forum
{
    public class Message
    {
        /// <summary>
        /// 
        /// </summary>
        public long Message_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Topic_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Utilisateur_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime DatePoste { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ContenuMessage { get; set; }
    }
}