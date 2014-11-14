using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOUP_Design.Models.Profile
{
    public class UtilisateurModel
    {

        [Required]
        [Display(Name = "Pseudo de l'utilisateur")]
        public string Pseudo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 5)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Le mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        [Display(Name = "Confirmez le mot de passe")]
        public string ConfirmPassword { get; set; }

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
        [Display(Name = "Adresse de l'utilisateur")]
        public string Adresse { get; set; }

    }
}