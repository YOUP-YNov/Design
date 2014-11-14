using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace YOUP_Design.Models.Forum
{
    public class TopicModel
    {
        [Required]
        [Display(Name = "Nom du topic")]
        public string Nom { get; set; }

        [Required]
        [Display(Name = "Description du topic")]
        public string DescriptionTopic { get; set; }
    }
}