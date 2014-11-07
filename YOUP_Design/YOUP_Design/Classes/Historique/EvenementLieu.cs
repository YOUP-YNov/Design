using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Design.Classes.Historique
{
    /// <summary>
    /// Model d'accès au données représentant un lieu d'événement.
    /// </summary>
    public class EvenementLieu
    {
        /// <summary>
        /// L'id de l'événement.
        /// </summary>
        private int _Id;
        /// <summary>
        /// Assigne ou récupère l'id de l'événement.
        /// </summary>
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        /// <summary>
        /// La ville de l'événement.
        /// </summary>
        private string _Ville;
        /// <summary>
        /// Assigne ou récupère la ville de l'événement.
        /// </summary>
        public string Ville
        {
            get { return _Ville; }
            set { _Ville = value; }
        }
        /// <summary>
        /// Le code postal de l'événement.
        /// </summary>
        private string _CodePostale;
        /// <summary>
        /// Assigne ou récupère le code postal de l'événement.
        /// </summary>
        public string CodePostale
        {
            get { return _CodePostale; }
            set { _CodePostale = value; }
        }
        /// <summary>
        /// Le pays de l'événement.
        /// </summary>
        private string _Pays;
        /// <summary>
        /// Assigne ou récupère le pays d'événement.
        /// </summary>
        public string Pays
        {
            get { return _Pays; }
            set { _Pays = value; }
        }
        /// <summary>
        /// La longitude de l'événement.
        /// </summary>
        private double _Longitude;
        /// <summary>
        /// Assigne ou récupère la longitude de l'événement.
        /// </summary>
        public double Longitude
        {
            get { return _Longitude; }
            set { _Longitude = value; }
        }
        /// <summary>
        /// La latitude de l'événement.
        /// </summary>
        private double _Latitute;
        /// <summary>
        /// Assigne ou récupère la latitude de l'événement.
        /// </summary>
        public double Latitute
        {
            get { return _Latitute; }
            set { _Latitute = value; }
        }
    }
}