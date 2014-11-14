using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace YOUP_Design.Models.Forum
{
    public class MessageModel
    {
        [Required]
        [Display(Name = "Contenu du message")]
        public string ContenuMessage { get; set; }

    }
}