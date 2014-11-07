using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOUP_Design.Classes.Blog
{
    public class Categorie
    {
        /// <summary>
        /// Assigne ou récupère l'id de la catégorie.
        /// </summary>
        public int Categorie_id { get; set; }
        /// <summary>
        /// Assigne ou récupère le libelle de la catégorie.
        /// </summary>
        public string Libelle { get; set; }
        /// <summary>
        /// COnstructeur vide de Catégorie.
        /// </summary>
        public Categorie()
        {

        }
    }
}
