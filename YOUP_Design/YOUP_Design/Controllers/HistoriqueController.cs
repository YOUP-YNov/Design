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
            return PartialView("~/Views/Historique/partialDevice.cshtml");
        }

        public ActionResult OS(string dateDebut, string dateFin)
        {
            return PartialView("~/Views/Historique/partialOS.cshtml");
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

        public ActionResult Saisonnalite()
        {
            return PartialView("~/Views/Historique/partialSaisonnalite.cshtml");
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
                ViewBag.Error = "Impossible de charger les utilisateurs";
            }

            if (string.IsNullOrEmpty(pseudoUser))
                return PartialView("~/Views/Historique/partialStatsUtilisation.cshtml", new Utilisateur());
            else
                return PartialView("~/Views/Historique/partialStatsUtilisation.cshtml", WebApiHistoriqueController.GetUtilisateurByPseudo(pseudoUser));
          }

        public ActionResult Tops()
        {
            return PartialView("~/Views/Historique/partialTops.cshtml", WebApiHistoriqueController.GetTops());
        }
    }
}
