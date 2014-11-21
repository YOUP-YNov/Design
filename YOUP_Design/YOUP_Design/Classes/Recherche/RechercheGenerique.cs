using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Design.Classes.Recherche
{
    public class RechercheGenerique
    {
        public List<Recherche> Gplace { get; set; }
        public List<Recherche> Gevent { get; set; }
        public List<Recherche> Gprofile { get; set; }
        public List<Recherche> Gpostforum { get; set; }
        public List<Recherche> Gblog { get; set; }
        public List<Recherche> Gblogpost { get; set; }
        public List<Recherche> Gblogpostcomment { get; set; }
        public RechercheGenerique()
        {

        }
    }
}