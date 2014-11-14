using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOUP_Design.Models.Blog
{
    public class CommentaireModel
    {
        [Required]
        [Display(Name = "Contenu du commentaire")]
        public string ContenuCommentaire { get; set; }
    }
}