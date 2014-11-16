using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YOUP_Design.Models.Evenement.webApiObjects;

namespace YOUP_Design.Models.Evenement.templatesObjects
{
    public class evenementTimeLineObject
    {
        public long idEvenement;
        public string titre;
        public string imgEvt;
        public string adresse;
        public string prix;
        public string description;
        public string date;
        public string ville;
        public string categorie;
        public int nbParticipant;
        public int nbMaxParticipant;
        public string imgOrganisateur;
        public string organisateur;

        public evenementTimeLineObject()
        {

        }

        public evenementTimeLineObject(EvenementTimelineFront evt)
        {
            this.idEvenement = evt.Evenement_id;
            this.titre = evt.TitreEvenement;
            this.imgEvt = "";
            this.adresse = evt.Adresse;
            this.prix = evt.Prix.ToString();
            this.description = "TODO";
            this.date = evt.DateEvenement.ToShortDateString();
            this.ville = evt.Adresse;
            this.categorie = evt.Categorie_id.ToString();
            this.nbParticipant = 0;
            this.nbMaxParticipant = 0;
            this.imgOrganisateur = "";
            this.organisateur = "";
        }
    }
}