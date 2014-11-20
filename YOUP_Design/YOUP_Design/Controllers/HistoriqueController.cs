using RestSharp;
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
        public T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient("http://youphistorique-wepapi.apphb.com/");
            var response = client.Execute<T>(request);
            return response.Data;
        }

        public Utilisateur GetUtilisateurByPseudo()
        {
            var request = new RestRequest("api/utilisateur/Collier", Method.GET);
            var result = Execute<Utilisateur>(request);

            return result;

        }
        public HistoriqueController()
        {
           
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Device()
        {
            return PartialView("~/Views/Historique/partialDeviceOS.cshtml");
        }

        public ActionResult PageVisitee()
        {
            return PartialView("~/Views/Historique/partialPagesVisitees.cshtml");
        }

        public ActionResult Saisonnalite()
        {
            return PartialView("~/Views/Historique/partialSaisonnalite.cshtml");
        }

        public ActionResult StatsUsage()
        {
            return PartialView("~/Views/Historique/partialStatsUtilisation.cshtml", WebApiHistoriqueController.GetUtilisateurs());
        }

        public ActionResult Tops()
        {
            return PartialView("~/Views/Historique/partialTops.cshtml", WebApiHistoriqueController.GetTops());
        }
    }
}
