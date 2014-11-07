
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Design.Classes.Profile
{
    public class Utilisateur
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
        public string MotDePasse { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<DateTime> DateInscription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Nom { get; set; }
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
        public string AdresseMail { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<DateTime> DateNaissance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Ville { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CodePostal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PhotoChemin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Situation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<bool> Actif { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<bool> Partenaire { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Presentation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Metier { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid Token { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<UtilisateurSmall> Amis { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Categorie> Categories { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public Utilisateur()
        {

        }

    }
}