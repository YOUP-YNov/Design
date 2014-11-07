
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Design.Classes.Profile
{
    public class UtilisateurPublic
    {
        /// <summary>
        /// 
        /// </summary>
        public int Utilisateur_Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Pseudo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<DateTime> DateInscription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Prenom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<bool> Sexe { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Ville { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PhotoChemin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Presentation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<UtilisateurSmall> Amis { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public UtilisateurPublic(){}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="utilisateur"></param>
        public UtilisateurPublic(Utilisateur utilisateur)
        {
            Utilisateur_Id = utilisateur.Utilisateur_Id;
            Pseudo = utilisateur.Pseudo;
            DateInscription = utilisateur.DateInscription;
            Prenom = utilisateur.Prenom;
            Sexe = utilisateur.Sexe;
            Ville = utilisateur.Ville;
            PhotoChemin = utilisateur.PhotoChemin;
            Presentation = utilisateur.Presentation;
            Amis = utilisateur.Amis;
        }
    }
}