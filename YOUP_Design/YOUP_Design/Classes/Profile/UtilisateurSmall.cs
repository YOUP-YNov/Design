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
        /// <summary>
        /// Assigne ou récupère l'id de l'utilisateur.
        /// </summary>
        public int Utilisateur_Id { get; set; }
        /// <summary>
        /// Assigne ou récupère le pseudo de l'utilisateur.
        /// </summary>
        public string Pseudo { get; set; }
        /// <summary>
        /// Assigne ou récupère le chemin de la photo de l'utilisateur.
        /// </summary>
        public string PhotoChemin { get; set; }
        /// <summary>
        /// Constructeur vide pour UtilisateurSmall.
        /// </summary>
        public UtilisateurSmall()
        {
                
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        public UtilisateurSmall(DataRow row)
        {
            Utilisateur_Id = Convert.ToInt32(row["Utilisateur_Id"]);
            Pseudo = row["Pseudo"] as string;
            PhotoChemin = row["PhotoChemin"] as string;
        }
    }
}
