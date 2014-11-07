using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Design.Classes.Historique
{
    public class Utilisateur
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
        private string _Pseudo;
        /// <summary>
        /// 
        /// </summary>
        public string Pseudo
        {
            get { return _Pseudo; }
            set { _Pseudo = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private bool _IsHomme;
        /// <summary>
        /// 
        /// </summary>
        public bool IsHomme
        {
            get { return _IsHomme; }
            set { _IsHomme = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string _Metier;
        /// <summary>
        /// 
        /// </summary>
        public string Metier
        {
            get { return _Metier; }
            set { _Metier = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private DateTime _DateInscription;
        /// <summary>
        /// 
        /// </summary>
        public DateTime DateInscription
        {
            get { return _DateInscription; }
            set { _DateInscription = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string _CheminPhoto;
        /// <summary>
        /// 
        /// </summary>
        public string CheminPhoto
        {
            get { return _CheminPhoto; }
            set { _CheminPhoto = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private int _Age;
        /// <summary>
        /// 
        /// </summary>
        public int Age
        {
            get { return _Age; }
            set { _Age = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private int _NbAmis;
        /// <summary>
        /// 
        /// </summary>
        public int NbAmis
        {
            get { return _NbAmis; }
            set { _NbAmis = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private int _NbEvenementPropose;
        /// <summary>
        /// 
        /// </summary>
        public int NbEvenmentPropose
        {
            get { return _NbEvenementPropose; }
            set { _NbEvenementPropose = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private int _NbEvenementParticipe;
        /// <summary>
        /// 
        /// </summary>
        public int NbEvenementParticipe
        {
            get { return _NbEvenementParticipe; }
            set { _NbEvenementParticipe = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string _Ville;
        /// <summary>
        /// 
        /// </summary>
        public string Ville
        {
            get { return _Ville; }
            set { _Ville = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string _CodePostale;
        /// <summary>
        /// 
        /// </summary>
        public string CodePostale
        {
            get { return _CodePostale; }
            set { _CodePostale = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private IEnumerable<Evenement> _EvenementsParticipes;
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Evenement> EvenementsParticipes
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
        /// 
        /// </summary>
        private IEnumerable<Evenement> _EvenementsCrees;
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Evenement> EvenementsCrees
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