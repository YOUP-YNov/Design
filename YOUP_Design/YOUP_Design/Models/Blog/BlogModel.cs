using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOUP_Design.Models.Blog
{
    public class BlogModel
    {
        [Required]
        [Display(Name = "Titre du blog")]
        public string TitreBlog { get; set; }

        [Required]
        [Display(Name = "Thème du blog")]
        public int ThemeId { get; set; }

        [Required]
        [Display(Name = "Catégorie du blog")]
        public int CategorieId { get; set; }
    }
}