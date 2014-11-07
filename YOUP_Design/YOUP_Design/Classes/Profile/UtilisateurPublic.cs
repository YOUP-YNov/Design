
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Design.Classes.Profile
{
    /// <summary>
    /// Model d'accès au données représentant un utilisateurpublic.
    /// </summary>
    public class UtilisateurPublic
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
        /// Assigne ou récupère la date d'inscription de l'utilisateur.
        /// </summary>
        public Nullable<DateTime> DateInscription { get; set; }
        /// <summary>
        /// Assigne ou récupère le prénom de l'utilisateur.
        /// </summary>
        public string Prenom { get; set; }
        /// <summary>
        /// Assigne ou récupère le sexe de l'utilisateur.
        /// </summary>
        public Nullable<bool> Sexe { get; set; }
        /// <summary>
        /// Assigne ou récupère la ville de l'utilisateur.
        /// </summary>
        public string Ville { get; set; }
        /// <summary>
        /// Assigne ou récupère le chemin de la photo de l'utilisateur.
        /// </summary>
        public string PhotoChemin { get; set; }
        /// <summary>
        /// Assigne ou récupère la présentation de l'utilisateur.
        /// </summary>
        public string Presentation { get; set; }
        /// <summary>
        /// Assigne ou récupère les amis de l'utilisateur.
        /// </summary>
        public List<UtilisateurSmall> Amis { get; set; }
        /// <summary>
        /// COnstructeur vide de UtilisateurPublic.
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