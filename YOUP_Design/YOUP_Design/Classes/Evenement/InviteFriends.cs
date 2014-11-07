using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Design.Classes.Evenement
{
    /// <summary>
    /// Model d'accès au données représentant les amis invités à un événement.
    /// </summary>
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