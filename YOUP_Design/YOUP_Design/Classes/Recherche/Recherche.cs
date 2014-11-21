using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Design.Classes.Recherche
{
    /// <summary>
    /// Model d'accès au données représentant un résultat de Recherche.
    /// </summary>
    public class Recherche
    {
        public string _type { get; set; }
        public int Score { get; set; }
        public Source _source { get; set; }

        public Recherche()
        {

        }
    }
}