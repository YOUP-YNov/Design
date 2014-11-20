using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YOUP_Design.Classes.Evenement;
using YOUP_Design.Models.Evenement.webApiObjects;

namespace YOUP_Design.Models.Evenement.templatesObjects
{
    public class evenementTimeLineObject
    {
        public long idEvenement;
        public string titre;
        public string imgEvt;
        public string prix;
        public string description;
        public string date;
        public string categorie;
        public int nbParticipant;
        public int nbMaxParticipant;
        public string imgOrganisateur;
        public string organisateur;
        public EventLocationFront adresse;
        public string hashTag = "";
        public string dateFinInscription = "";
        public bool premium = false;
        //attribut public
        public bool visible = true;

        public evenementTimeLineObject()
        {

        }

        public evenementTimeLineObject(EvenementTimelineFront evt)
        {
            this.idEvenement = evt.Evenement_id;
            this.titre = evt.TitreEvenement;
            this.imgEvt = evt.ImageUrl ?? "";
            this.adresse = evt.Adresse;
            this.prix = evt.Prix.ToString();
            this.description = evt.DescriptionEvenement;
            this.date = evt.DateEvenement.ToShortDateString();
            this.categorie = evt.Categorie_Libelle.ToString();
            this.nbParticipant = 0;
            this.nbMaxParticipant = 0;
            this.imgOrganisateur = evt.OrganisateurImageUrl;
            this.organisateur = evt.OrganisateurPseudo;
        }

         public evenementTimeLineObject(EvenementFront evt)
        {
            this.idEvenement = evt.Id;
            this.titre = evt.TitreEvenement;
            this.imgEvt = evt.Galleries != null && evt.Galleries.FirstOrDefault() != null ? evt.Galleries.FirstOrDefault().Url : "";
            this.adresse = evt.EventAdresse;
            this.prix = evt.Price.ToString();
            this.description = evt.DescriptionEvenement;
            this.date = evt.DateEvenement.ToShortDateString();
            this.categorie = evt.Categorie != null ? evt.Categorie.Libelle : "";
            this.nbParticipant = 0;
            this.nbMaxParticipant = evt.MaximumParticipant;
            this.imgOrganisateur = evt.OrganisateurImageUrl;
            this.organisateur = evt.OrganisateurPseudo;
            this.hashTag = "";
            if (evt.HashTag != null)
            {
                evt.HashTag.ToList().ForEach(t => this.hashTag += t + "; ");
            }
            this.dateFinInscription = evt.DateFinInscription.ToShortDateString();
            this.premium = evt.Premium;
            //attribut public
            this.visible = evt.Public;
        }
    }
}