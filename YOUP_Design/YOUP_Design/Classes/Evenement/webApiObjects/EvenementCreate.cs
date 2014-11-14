using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Design.Classes.Evenement.webApiObjects
{
    public class EvenementCreate
    {
        public EvenementFront evenement { get; set; }
        public List<long> friends { get; set; }
    }
}