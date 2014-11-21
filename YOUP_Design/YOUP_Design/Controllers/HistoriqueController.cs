using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YOUP_Design.Classes.Historique;
using YOUP_Design.WebApi.Historique;

namespace YOUP_Design.Controllers
{
    public class HistoriqueController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Device(string dateDebut, string dateFin)
        {
            if (string.IsNullOrEmpty(dateDebut) || string.IsNullOrEmpty(dateFin))
            {
                return PartialView("~/Views/Historique/partialDevice.cshtml", new List<DeviceCategoryStatRow>());
            }
            else
            {
                ViewBag.DateDebut = dateDebut;
                ViewBag.DateFin = dateFin;
                return PartialView("~/Views/Historique/partialDevice.cshtml", WebApiHistoriqueController.GetDeviceCategorie(dateDebut, dateFin));
            }
        }

        public ActionResult OS(string dateDebut, string dateFin)
        {
            if (string.IsNullOrEmpty(dateDebut) || string.IsNullOrEmpty(dateFin))
            {
                return PartialView("~/Views/Historique/partialOS.cshtml", new List<DeviceTypeStatRow>());
            }
            else
            {
                ViewBag.DateDebut = dateDebut;
                ViewBag.DateFin = dateFin;
                return PartialView("~/Views/Historique/partialOS.cshtml", WebApiHistoriqueController.GetDeviceType(dateDebut, dateFin));
            }
        }
        public ActionResult PageVisitee(string dateDebut, string dateFin)
        {
            if(string.IsNullOrEmpty(dateDebut)|| string.IsNullOrEmpty(dateFin))
            {
                return PartialView("~/Views/Historique/partialPagesVisitees.cshtml", new List<PageVisitee>());
            }
            else
            {
                ViewBag.DateDebut = dateDebut;
                ViewBag.DateFin = dateFin;
                return PartialView("~/Views/Historique/partialPagesVisitees.cshtml", WebApiHistoriqueController.GetPageVisitee(dateDebut,dateFin));
            }
        }

        public ActionResult Saisonnalite(string dateDebut, string dateFin)
        {
            if (string.IsNullOrEmpty(dateDebut) || string.IsNullOrEmpty(dateFin))
            {
                return PartialView("~/Views/Historique/partialSaisonnalite.cshtml", new List<Evenement>());
            }
            else
            {
                ViewBag.DateDebut = dateDebut;
                ViewBag.DateFin = dateFin;
                return PartialView("~/Views/Historique/partialSaisonnalite.cshtml", WebApiHistoriqueController.GetEvenementParSaisonalite(dateDebut, dateFin));
            }
        }

        public ActionResult StatsUsage(string pseudoUser)
        {
            List<SelectListItem> pseudos = new List<SelectListItem>();
            var users = WebApiHistoriqueController.GetUtilisateurs();
            if(users != null)
            {
                users.ForEach(x => pseudos.Add(new SelectListItem() { Text = x.Pseudo, Value = x.Pseudo }));
                ViewBag.Pseudo = new SelectList(pseudos, "Value", "Text");
            }
            else
            {
                ViewBag.Pseudo = new SelectList(new List<SelectListItem>(), "Value", "Text");
                ViewBag.MsgError = "Impossible de charger les utilisateurs";
            }

            if (string.IsNullOrEmpty(pseudoUser))
            {
                ViewBag.EventsByCategory = new Dictionary<string, int>();
                return PartialView("~/Views/Historique/partialStatsUtilisation.cshtml", new Utilisateur());
            }
            else
            {
                var user =WebApiHistoriqueController.GetUtilisateurByPseudo(pseudoUser);
                ViewBag.EventsByCategory = NbEvenementByCategorie(user.Id);
                return PartialView("~/Views/Historique/partialStatsUtilisation.cshtml",user );
            }
          }

        public ActionResult Tops()
        {
            return PartialView("~/Views/Historique/partialTops.cshtml", WebApiHistoriqueController.GetTops());
        }

        public static Dictionary<string,int> NbEvenementByCategorie(Utilisateur user)
        {
            var nbEvenementByCategorie = new Dictionary<string, int>();

            foreach(var evenement in user.EvenementsParticipes)
            {
                if(nbEvenementByCategorie.ContainsKey(evenement.Categorie.Libelle))
                {
                    nbEvenementByCategorie[evenement.Categorie.Libelle] = nbEvenementByCategorie[evenement.Categorie.Libelle] + 1;
                }
                else
                {
                    nbEvenementByCategorie.Add(evenement.Categorie.Libelle, 1);
                }
            }
            return nbEvenementByCategorie;
        }

        public static Dictionary<string, int> NbEvenementByCategorie(int userId)
        {
            var nbEvenementByCategorie = new Dictionary<string, int>();
            var evenements = WebApiHistoriqueController.GetEvenementParticipeByUser(userId);
            if(evenements != null)
            {
                foreach (var evenement in evenements)
                {
                    if (nbEvenementByCategorie.ContainsKey(evenement.Categorie.Libelle))
                    {
                        nbEvenementByCategorie[evenement.Categorie.Libelle] = nbEvenementByCategorie[evenement.Categorie.Libelle] + 1;
                    }
                    else
                    {
                        nbEvenementByCategorie.Add(evenement.Categorie.Libelle, 1);
                    }
                }
            }            
            return nbEvenementByCategorie;
        }
    }
}
