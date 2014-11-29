using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using YOUP_Design.Classes.Evenement;

namespace YOUP_Design.Models.Evenement
{
    public class EventCreation
    {
        [Required]
        public string TitreEvenement { get; set; }

        [Required]
        public DateTime DateEvenement { get; set; }

        [Required]
        public string DescriptionEvenement { get; set; }

        [Required]
        public int MaximumParticipant { get; set; }

        [Required]
        public int Prix { get; set; }

        [Required]
        public bool Public { get; set; }

        public string MotsCles { get; set; }

        [Required]
        public string Adresse { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public string ImageUrl { get; set; }


        public long OrganisateurId { get; set; }

    }
}