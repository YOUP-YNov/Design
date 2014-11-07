using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Design.Classes.Historique
{
    public class EvenementLieu
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
        private string _Pays;
        /// <summary>
        /// 
        /// </summary>
        public string Pays
        {
            get { return _Pays; }
            set { _Pays = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private double _Longitude;
        /// <summary>
        /// 
        /// </summary>
        public double Longitude
        {
            get { return _Longitude; }
            set { _Longitude = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private double _Latitute;
        /// <summary>
        /// 
        /// </summary>
        public double Latitute
        {
            get { return _Latitute; }
            set { _Latitute = value; }
        }
    }
}