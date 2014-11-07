using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOUP_Design.Classes.Profile
{
    public class UtilisateurSmall
    {

        public int Utilisateur_Id { get; set; }
        public string Pseudo { get; set; }
        public string PhotoChemin { get; set; }

        public UtilisateurSmall()
        {
                
        }

        public UtilisateurSmall(DataRow row)
        {
            Utilisateur_Id = Convert.ToInt32(row["Utilisateur_Id"]);
            Pseudo = row["Pseudo"] as string;
            PhotoChemin = row["PhotoChemin"] as string;
        }
    }
}
