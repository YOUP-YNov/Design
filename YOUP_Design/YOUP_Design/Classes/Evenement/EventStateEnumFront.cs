﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Design.Classes.Evenement
{
    /// <summary>
    /// Enumération des statuts de l'evènement.
    /// </summary>
    public enum EventStateEnum
    {
        AValider = 11,
        Valide = 12,
        Annuler = 13,
        Signaler = 14,
        Reussi = 15,
        Desactiver = 16
    }
}