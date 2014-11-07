using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Design.Classes.Forum
{
    public class Topic
    {
        /// <summary>
        /// 
        /// </summary>
        public long Topic_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Sujet_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Nom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DescriptifTopic { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime DateCreation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Resolu { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Utilisateur_id { get; set; }

    }
}