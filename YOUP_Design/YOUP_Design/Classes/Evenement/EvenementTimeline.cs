using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Design.Classes.Evenement
{
    public class EvenementTimelineFront
    {
        /// <summary>
        /// 
        /// </summary>
        public long Evenement_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long LieuEvenement_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Categorie_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime DateEvenement { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TitreEvenement { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int MaximumParticipant { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Statut { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Prix { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Premium { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime DateMiseEnAvant { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Etat_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long EvenementPhoto_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Adresse { get; set; }

    }
}