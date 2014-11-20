
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Design.Classes.Profile
{
    /// <summary>
    /// Model d'accès au données représentant un utilisateur.
    /// </summary>
    public class Utilisateur
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
        /// Assigne ou récupère le mot de passe de lutilisateur.
        /// </summary>
        public string MotDePasse { get; set; }
        /// <summary>
        /// Assigne ou récupère la date d'inscription de l'utilisateur.
        /// </summary>
        public Nullable<DateTime> DateInscription { get; set; }
        /// <summary>
        /// Assigne ou récupère le nom de l'utilisateur.
        /// </summary>
        public string Nom { get; set; }
        /// <summary>
        /// Assigne ou récupère le prénom de l'utilisateur.
        /// </summary>
        public string Prenom { get; set; }
        /// <summary>
        /// Assigne ou récupère le sexe de l'utilisateur.
        /// </summary>
        public Nullable<bool> Sexe { get; set; }
        /// <summary>
        /// Assigne ou récupère l'adresse mail de l'utilisateur.
        /// </summary>
        public string AdresseMail { get; set; }
        /// <summary>
        /// Assigne ou récupère la date de naissance de l'utilisateur.
        /// </summary>
        public Nullable<DateTime> DateNaissance { get; set; }
        /// <summary>
        /// Assigne ou récupère la ville de l'utilisateur.
        /// </summary>
        public string Ville { get; set; }
        /// <summary>
        /// Assigne ou récupère le code postal de l'utilisateur.
        /// </summary>
        public string CodePostal { get; set; }
        /// <summary>
        /// Assigne ou récupère le chemin de la photo de l'utilisateur.
        /// </summary>
        public string PhotoChemin { get; set; }
        /// <summary>
        /// Assigne ou récupère la situation de l'utilisateur.
        /// </summary>
        public string Situation { get; set; }
        /// <summary>
        /// Assigne ou récupère l'activité de l'utilisateurs.
        /// </summary>
        public Nullable<bool> Actif { get; set; }
        /// <summary>
        /// Assigne ou récupère si l'utilisateur est partenaire ou non.
        /// </summary>
        public Nullable<bool> Partenaire { get; set; }
        /// <summary>
        /// Assigne ou récupère la présentation de l'utilisateur.
        /// </summary>
        public string Presentation { get; set; }
        /// <summary>
        /// Assigne ou récupère le métier de l'utilisateur.
        /// </summary>
        public string Metier { get; set; }
        /// <summary>
        /// Assigne ou récupère.
        /// </summary>
        public Guid Token { get; set; }
        /// <summary>
        /// Assigne ou récupère les amis de l'utilisateur.
        /// </summary>
        public List<UtilisateurSmall> Amis { get; set; }
        /// <summary>
        /// Assigne ou récupère.
        /// </summary>
        public List<Categorie> Categories { get; set; }
        /// <summary>
        /// Constructeur vide d'utilisateur.
        /// </summary>
        public Utilisateur()
        {

        }

    }
}