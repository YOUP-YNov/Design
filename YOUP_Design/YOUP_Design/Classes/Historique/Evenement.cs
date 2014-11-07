using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Design.Classes.Historique
{
    public class Evenement
    {
        /// <summary>
        /// 
        /// </summary>
        private int _Id;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private int _IdUser;
        /// <summary>
        /// 
        /// </summary>
        public int IdUser
        {
            get { return _IdUser; }
            set { _IdUser = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private DateTime _DateEvenement;
        /// <summary>
        /// 
        /// </summary>
        public DateTime DateEvenement
        {
            get { return _DateEvenement; }
            set { _DateEvenement = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private DateTime _DateModification;
        /// <summary>
        /// 
        /// </summary>
        public DateTime DateModification
        {
            get { return _DateModification; }
            set { _DateModification = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private DateTime _DateFinIncription;
        /// <summary>
        /// 
        /// </summary>
        public DateTime DateFinIncription
        {
            get { return _DateFinIncription; }
            set { _DateFinIncription = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string _Titre;
        /// <summary>
        /// 
        /// </summary>
        public string Titre
        {
            get { return _Titre; }
            set { _Titre = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string _Description;
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private int _NbMaxParticipant;
        /// <summary>
        /// 
        /// </summary>
        public int NbMaxParticipant
        {
            get { return _NbMaxParticipant; }
            set { _NbMaxParticipant = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private int _NbMinParticipant;
        /// <summary>
        /// 
        /// </summary>
        public int NbMinParticipant
        {
            get { return _NbMinParticipant; }
            set { _NbMinParticipant = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private double _Prix;
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        public bool Premium
        {
            get { return _Premium; }
            set { _Premium = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string _Etat;
        /// <summary>
        /// 
        /// </summary>
        public string Etat
        {
            get { return _Etat; }
            set { _Etat = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string _Statut;
        /// <summary>
        /// 
        /// </summary>
        public string Statut
        {
            get { return _Statut; }
            set { _Statut = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private Categorie _Categorie;
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        private EvenementLieu _Lieu;
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        private IEnumerable<Utilisateur> _Participants;
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        private Utilisateur _Createur;
        /// <summary>
        /// 
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