using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YOUP_Design.Models.Profile
{
    public class ProfileModelBinding
    {
        [Required(ErrorMessage="Le champs email doit être renseigné")]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage="Le champs mot de passe doit être renseigné")]
        public string Password { get; set; }
    }
}