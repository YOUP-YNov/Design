using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOUP_Design.Models.Blog
{
    public class ArticleModel
    {
        [Display(Name = "id de l'article")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Titre de l'article")]
        public string TitreArticle { get; set; }

        [Required]
        [Display(Name = "Chemin de l'image de l'article")]
        public string ImageChemin { get; set; }
        
        [Required]
        [Display(Name = "Contenu de l'article")]
        public string ContenuArticle { get; set; }

        [Required]
        [Display(Name = "Actif")]
        public bool Actif { get; set; }

        [Required]
        [Display(Name = "Evenement lié à l'article")]
        public int EventId { get; set; }

        [Required]
        [Display(Name = "Tags de l'article")]
        public string Tags { get; set; }
    }
}