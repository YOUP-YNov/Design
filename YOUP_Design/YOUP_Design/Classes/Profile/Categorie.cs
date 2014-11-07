using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOUP_Design.Classes.Profile
{
    /// <summary>
    /// Model d'accès au données représentant une catégorie.
    /// </summary>
    public class Categorie
    {
        /// <summary>
        /// Assigne ou récupère l'id de la catégorie.
        /// </summary>
        public int Categorie_id;
        /// <summary>
        /// Assigne ou récupère le libelle de la catégorie.
        /// </summary>
        public string Libelle;
        /// <summary>
        /// Constructeur vide de la catégorie.
        /// </summary>
        public Categorie()
        {
                
        }
        /// <summary>
        /// Constructeur de Categorie.
        /// </summary>
        /// <param name="row"></param>
        public Categorie(DataRow row)
        {
            Categorie_id    = Convert.ToInt32(row["Utilisateur_id"]);
            Libelle = row["Libelle"] as string;
        }
    }
}
