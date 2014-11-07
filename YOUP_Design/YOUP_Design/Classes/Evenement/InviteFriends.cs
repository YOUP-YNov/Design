using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Design.Classes.Evenement
{
    
    public class InviteFriends
    {
        /// <summary>
        /// Id de l'evenement.
        /// </summary>
        public long idEvent;
        /// <summary>
        /// Id de l'utilisateur.
        /// </summary>
        public long idUser;
        /// <summary>
        /// Liste d'IDs d'amis.
        /// </summary>
        public List<long> idFriends;
    }
}