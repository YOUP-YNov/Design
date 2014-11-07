using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Design.Classes.Historique
{
    public class Categorie
    {
        /// <summary>
        /// Id de la catégorie.
        /// </summary>
        private int _Id;
        /// <summary>
        /// Assigne ou récupère l'id de la catégorie.
        /// </summary>
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        /// <summary>
        /// Libelle de la catégorie.
        /// </summary>
        private string _Libelle;
        /// <summary>
        /// Assigne ou récupère le libelle de la catégorie.
        /// </summary>
        public string Libelle
        {
            get { return _Libelle; }
            set { _Libelle = value; }
        }
    }
}