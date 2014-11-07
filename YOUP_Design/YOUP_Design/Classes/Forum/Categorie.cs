using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Design.Classes.Forum
{
    public class Categorie
    {
        public long Sujet_id { get; set; }
        public long Forum_id { get; set; }
        public string Nom { get; set; }
    }
}