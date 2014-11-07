using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOUP_Design.Classes.Evenement
{
    /// <summary>
    /// Model d'accès au données représentant la catégorie d'un événement.
    /// </summary>
    public class EvenementCategorieFront
    {
        /// <summary>
        /// Id de la catégorie de l'event.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Libelle de la catégorie de l'event.
        /// </summary>
        public string Libelle { get; set; }
    }
}
