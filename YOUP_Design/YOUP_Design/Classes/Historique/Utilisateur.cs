using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Design.Classes.Historique
{
    /// <summary>
    /// Model d'accès au données représentant un utilisateur.
    /// </summary>
    public class Utilisateur
    {
        /// <summary>
        /// L'id de l'utilisateur.
        /// </summary>
        private int _Id;
        /// <summary>
        /// Assigne ou récupère l'id de l'utilisateur.
        /// </summary>
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        /// <summary>
        /// Le pseudo de l'utilisateur.
        /// </summary>
        private string _Pseudo;
        /// <summary>
        /// Assigne ou récupère le pesudo de l'utilisateur.
        /// </summary>
        public string Pseudo
        {
            get { return _Pseudo; }
            set { _Pseudo = value; }
        }
        /// <summary>
        /// Le sexe de l'utilisateur.
        /// </summary>
        private bool _IsHomme;
        /// <summary>
        /// Assigne ou récupère le sexe de l'utilisateur.
        /// </summary>
        public bool IsHomme
        {
            get { return _IsHomme; }
            set { _IsHomme = value; }
        }
        /// <summary>
        /// Le métier de l'utilisateur.
        /// </summary>
        private string _Metier;
        /// <summary>
        /// Assigne ou récupère le métieur de l'utilisateur.
        /// </summary>
        public string Metier
        {
            get { return _Metier; }
            set { _Metier = value; }
        }
        /// <summary>
        /// La date d'inscription de l'utilisateur.
        /// </summary>
        private DateTime _DateInscription;
        /// <summary>
        /// Assigne ou récupère la date d'incripstion de l'utilisateur.
        /// </summary>
        public DateTime DateInscription
        {
            get { return _DateInscription; }
            set { _DateInscription = value; }
        }
        /// <summary>
        /// Le chemin de la photo de l'utilisateur.
        /// </summary>
        private string _CheminPhoto;
        /// <summary>
        /// Assigne ou récupère le chemin de la photo de l'utilisateur.
        /// </summary>
        public string CheminPhoto
        {
            get { return _CheminPhoto; }
            set { _CheminPhoto = value; }
        }
        /// <summary>
        /// L'age de l'utilisateur.
        /// </summary>
        private int _Age;
        /// <summary>
        /// Assigne ou récupère l'age de l'utilisateur.
        /// </summary>
        public int Age
        {
            get { return _Age; }
            set { _Age = value; }
        }
        /// <summary>
        /// Le nombre d'amis de l'utilisateur.
        /// </summary>
        private int _NbAmis;
        /// <summary>
        /// Assigne ou récupère le nombre d'amis de l'utilisateur.
        /// </summary>
        public int NbAmis
        {
            get { return _NbAmis; }
            set { _NbAmis = value; }
        }
        /// <summary>
        /// Le nombre d'évenement proposés par l'utilisateur.
        /// </summary>
        private int _NbEvenementPropose;
        /// <summary>
        /// Assigne ou récupère le nombre d'événement proposés par l'utilisateur.
        /// </summary>
        public int NbEvenmentPropose
        {
            get { return _NbEvenementPropose; }
            set { _NbEvenementPropose = value; }
        }
        /// <summary>
        /// Le nombre d'événement auxquels l'utilisateur a participer.
        /// </summary>
        private int _NbEvenementParticipe;
        /// <summary>
        /// Assigne ou récupère le nombre d'évenement auxquels l'utilisateur a participer.
        /// </summary>
        public int NbEvenementParticipe
        {
            get { return _NbEvenementParticipe; }
            set { _NbEvenementParticipe = value; }
        }
        /// <summary>
        /// La ville de l'utilisateur.
        /// </summary>
        private string _Ville;
        /// <summary>
        /// Assigne ou récupère la ville de l'utilisateur.
        /// </summary>
        public string Ville
        {
            get { return _Ville; }
            set { _Ville = value; }
        }
        /// <summary>
        /// Le code postal de l'utilisateur.
        /// </summary>
        private string _CodePostale;
        /// <summary>
        /// Assigne ou récupère le code postal de l'utilisateur.
        /// </summary>
        public string CodePostale
        {
            get { return _CodePostale; }
            set { _CodePostale = value; }
        }
        /// <summary>
        /// Evenement auxquels l'utilisateur a participer.
        /// </summary>
        private List<Evenement> _EvenementsParticipes;
        /// <summary>
        /// Assigne ou récupère les évenement auxquels l'utilisateur a participer.
        /// </summary>
        public List<Evenement> EvenementsParticipes
        {
            get
            {
                if (_EvenementsParticipes == null)
                    _EvenementsParticipes = new List<Evenement>();
                return _EvenementsParticipes;
            }
            set { _EvenementsParticipes = value; }
        }
        /// <summary>
        /// Evenement créés par l'utilisateur.
        /// </summary>
        private List<Evenement> _EvenementsCrees;
        /// <summary>
        /// Assigne ou récupère les évenement créés par l'utilisateur.
        /// </summary>
        public List<Evenement> EvenementsCrees
        {
            get
            {
                if (_EvenementsCrees == null)
                    _EvenementsCrees = new List<Evenement>();
                return _EvenementsCrees;
            }
            set { _EvenementsCrees = value; }
        }
    }
}