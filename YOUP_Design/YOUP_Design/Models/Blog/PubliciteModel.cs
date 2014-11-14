using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOUP_Design.Models.Blog
{
    public class PubliciteModel
    {
        [Required]
        [Display(Name = "Contenu de la pub")]
        public string ContenuPublicite { get; set; }

        [Required]
        [Display(Name = "Hauteur de la pub")]
        public int Hauteur { get; set; }

        [Required]
        [Display(Name = "Largeur de la pub")]
        public int Largeur { get; set; }
    }
}