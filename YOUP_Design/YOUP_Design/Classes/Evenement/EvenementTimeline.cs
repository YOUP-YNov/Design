using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Design.Classes.Evenement
{
    public class EvenementTimelineFront
    {
        /// <summary>
        /// Assigne ou récupère l'id de l'evènement.
        /// </summary>
        public long Evenement_id { get; set; }
        /// <summary>
        /// Assigne ou récupère l'id du lieu de l'evènement.
        /// </summary>
        public long LieuEvenement_id { get; set; }
        /// <summary>
        /// Assigne ou récupère l'id de la catégorie de l'evènement.
        /// /// </summary>
        public long Categorie_id { get; set; }
        /// <summary>
        /// Assigne ou récupère la date de l'evenement.
        /// </summary>
        public DateTime DateEvenement { get; set; }
        /// <summary>
        /// Assigne ou récupère le titre de l'evènement.
        /// </summary>
        public string TitreEvenement { get; set; }
        /// <summary>
        /// Assigne ou récupère le nombre maximum de participant à l'evènement.
        /// </summary>
        public int MaximumParticipant { get; set; }
        /// <summary>
        /// Assigne ou récupère le statut de l'evènement.
        /// </summary>
        public string Statut { get; set; }
        /// <summary>
        /// Assigne ou récupère le prix de l'evènement.
        /// </summary>
        public int Prix { get; set; }
        /// <summary>
        /// Assigne ou récupère si l'evènement est prenium ou non.
        /// </summary>
        public bool Premium { get; set; }
        /// <summary>
        /// Assigne ou récupère la date de mise en avant de l'evènement.
        /// </summary>
        public DateTime DateMiseEnAvant { get; set; }
        /// <summary>
        /// Assigne ou récupère l'id de l'etat de l'evènement.
        /// </summary>
        public long Etat_id { get; set; }
        /// <summary>
        /// Assigne ou récupère l'id de la photo de l'evènement.
        /// </summary>
        public long EvenementPhoto_id { get; set; }
        /// <summary>
        /// Assigne ou récupère l'adresse de l'evènement.
        /// </summary>
        public string Adresse { get; set; }

    }
}