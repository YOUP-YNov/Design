using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Design.Classes.Historique
{
    /// <summary>
    /// Model d'accès au données représentant un événement.
    /// </summary>
    public class Evenement
    {
        /// <summary>
        /// Id de l'evènement.
        /// </summary>
        private int _Id;
        /// <summary>
        /// Assigne ou récupère l'id de l'evènement.
        /// </summary>
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        /// <summary>
        /// Id de l'utilisateur.
        /// </summary>
        private int _IdUser;
        /// <summary>
        /// Assigne ou récupère l'id de l'utilisateur.
        /// </summary>
        public int IdUser
        {
            get { return _IdUser; }
            set { _IdUser = value; }
        }
        /// <summary>
        /// Date de l'evènement.
        /// </summary>
        private DateTime _DateEvenement;
        /// <summary>
        /// Assigne ou récupère la date de l'evènement.
        /// </summary>
        public DateTime DateEvenement
        {
            get { return _DateEvenement; }
            set { _DateEvenement = value; }
        }
        /// <summary>
        /// Date de modification de l'evènement.
        /// </summary>
        private DateTime _DateModification;
        /// <summary>
        /// Assigne ou récupère la date de modification de l'evènement.
        /// </summary>
        public DateTime DateModification
        {
            get { return _DateModification; }
            set { _DateModification = value; }
        }
        /// <summary>
        /// Date de fin d'inscription à l'evènement.
        /// </summary>
        private DateTime _DateFinIncription;
        /// <summary>
        /// Assigne ou récupère la date de fon d'inscription à l'evènement.
        /// </summary>
        public DateTime DateFinIncription
        {
            get { return _DateFinIncription; }
            set { _DateFinIncription = value; }
        }
        /// <summary>
        /// Titre de l'evènement.
        /// </summary>
        private string _Titre;
        /// <summary>
        /// Assigne ou récupère le titre de l'evènement.
        /// </summary>
        public string Titre
        {
            get { return _Titre; }
            set { _Titre = value; }
        }
        /// <summary>
        /// Description de l'evènement.
        /// </summary>
        private string _Description;
        /// <summary>
        /// Assigne ou récupère la description de l'evènement.
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        /// <summary>
        /// Nombre maximum de participants à l'evènement.
        /// </summary>
        private int _NbMaxParticipant;
        /// <summary>
        /// Assigne ou récupère le nombre maximum de participants à l'evènement.
        /// </summary>
        public int NbMaxParticipant
        {
            get { return _NbMaxParticipant; }
            set { _NbMaxParticipant = value; }
        }
        /// <summary>
        /// Nombre minimum de participants à l'evènement.
        /// </summary>
        private int _NbMinParticipant;
        /// <summary>
        /// Assigne ou récupère le nombre minimum de participants à l'evènement.
        /// </summary>
        public int NbMinParticipant
        {
            get { return _NbMinParticipant; }
            set { _NbMinParticipant = value; }
        }
        /// <summary>
        /// Prix de l'evènement.
        /// </summary>
        private double _Prix;
        /// <summary>
        /// Assigne ou récupère le prix de l'evènement.
        /// </summary>
        public double Prix
        {
            get { return _Prix; }
            set { _Prix = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private bool _Premium;
        /// <summary>
        /// Assigne ou récupère la valeur pour savoir si l'evènement est premium.
        /// </summary>
        public bool Premium
        {
            get { return _Premium; }
            set { _Premium = value; }
        }
        /// <summary>
        /// Etat de l'evènement.
        /// </summary>
        private string _Etat;
        /// <summary>
        /// Assigne ou récupère l'état de l'evènement.
        /// </summary>
        public string Etat
        {
            get { return _Etat; }
            set { _Etat = value; }
        }
        /// <summary>
        /// Statut de l'evènement.
        /// </summary>
        private string _Statut;
        /// <summary>
        /// Assigne ou récupère le statut de l'evènement.
        /// </summary>
        public string Statut
        {
            get { return _Statut; }
            set { _Statut = value; }
        }
        /// <summary>
        /// Catégorie de l'evènement.
        /// </summary>
        private Categorie _Categorie;
        /// <summary>
        /// Assigne ou récupère la catégorie de l'evènement.
        /// </summary>
        public Categorie Categorie
        {
            get
            {
                if (_Categorie == null)
                    _Categorie = new Categorie();
                return _Categorie;
            }
            set { _Categorie = value; }
        }
        /// <summary>
        /// Lieu de l'evènement.
        /// </summary>
        private EvenementLieu _Lieu;
        /// <summary>
        /// Assigne ou récupère le lieu de l'evènement.
        /// </summary>
        public EvenementLieu Lieu
        {
            get
            {
                if (_Lieu == null)
                    _Lieu = new EvenementLieu();
                return _Lieu;
            }
            set
            {
                _Lieu = value;
            }
        }
        /// <summary>
        /// Liste de participants.
        /// </summary>
        private IEnumerable<Utilisateur> _Participants;
        /// <summary>
        /// Assigne ou récupère une liste de participants.
        /// </summary>
        public IEnumerable<Utilisateur> Participants
        {
            get
            {
                if (_Participants == null)
                    _Participants = new List<Utilisateur>();
                return _Participants;
            }
            set
            {
                _Participants = value;
            }
        }
        /// <summary>
        /// Createur de l'evènement.
        /// </summary>
        private Utilisateur _Createur;
        /// <summary>
        /// Assigne ou récupère le createur de l'evènement.
        /// </summary>
        public Utilisateur Createur
        {
            get
            {
                if (_Createur == null)
                    _Createur = new Utilisateur();
                return _Createur;
            }
            set
            {
                _Createur = value;
            }
        }
    }
}