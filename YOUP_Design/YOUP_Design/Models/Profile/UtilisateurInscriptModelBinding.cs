using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOUP_Design.Models.Profile
{
    public class UtilisateurInscriptModelBinding
    {

        [Required]
        [Display(Name = "Pseudo")]
        public string Pseudo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Nom de l'utilisateur")]
        public string Nom { get; set; }

        [Required]
        [Display(Name = "Prénom de l'utilisateur")]
        public string Prenom { get; set; }

        [Required]
        [Display(Name = "Adresse email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime DateNaissance { get; set; }

        public string PhotoUrl { get; set; }

        [Required]
        public string CodePostal { get; set; }

        [Required]
        public string Ville { get; set; }

    }
}