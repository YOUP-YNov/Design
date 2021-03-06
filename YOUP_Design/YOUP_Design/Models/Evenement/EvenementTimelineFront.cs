﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YOUP_Design.Classes.Evenement;

namespace YOUP_Design.Models.Evenement.webApiObjects
{
    public class EvenementTimelineFront
    {
        public long Evenement_id { get; set; }
        public string Categorie_Libelle { get; set; }
        public DateTime DateEvenement { get; set; }
        public string TitreEvenement { get; set; }
        public int MaximumParticipant { get; set; }
        public string Statut { get; set; }
        public int Prix { get; set; }
        public bool Premium { get; set; }
        public DateTime DateMiseEnAvant { get; set; }
        public string Etat { get; set; }
        public long EvenementPhoto_id { get; set; }
        public EventLocationFront Adresse { get; set; }
        public string DescriptionEvenement { get; set; }
        public string ImageUrl { get; set; }
        public string OrganisateurPseudo { get; set; }	
        public string OrganisateurImageUrl { get; set; }
        public int NbParticipant { get; set; }
        public DateTime DateFinInscription { get; set; }
    }
}