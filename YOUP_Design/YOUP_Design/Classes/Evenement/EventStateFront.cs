﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOUP_Design.Classes.Evenement
{
    /// <summary>
    /// Model d'accès au données représentant l'état d'un événement.
    /// </summary>
    public class EventStateFront
    {
        /// <summary>
        /// Assigne ou récupère le libelle de l'état de l'évenement.
        /// </summary>
        public EventStateEnum Nom { get; set; }

        /// <summary>
        /// Assigne ou récupère l'id de l'état de l'évenement.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Constructeur de EventStateFront
        /// </summary>
        /// <param name="name"></param>
        public EventStateFront(EventStateEnum name)
        {
            Nom = name;
            Id = (long)name;
        }

        /// <summary>
        /// Constructeur de EventStateFront
        /// </summary>
        public EventStateFront()
        {

        }
    }
}
