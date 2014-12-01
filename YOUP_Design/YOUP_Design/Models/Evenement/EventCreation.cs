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
        [MinLength(3)]
        public string TitreEvenement { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateEvenement { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime Heure { get; set; }

        [Required]
        [MinLength(10)]
        public string DescriptionEvenement { get; set; }

        [Required]
        [Range(2, 10000)]
        public int MaximumParticipant { get; set; }

        [Required]
        [Range(0, 10000)]
        public int Prix { get; set; }

        public bool Public { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateFinInscription { get; set; }

        public string MotsCles { get; set; }

        [Required]
        public string Adresse { get; set; }

        [Required]
        public int Categorie { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Address { get; set; }

        public string ImageUrl { get; set; }

        public long OrganisateurId { get; set; }

    }
}