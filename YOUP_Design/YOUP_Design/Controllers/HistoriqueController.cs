using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return PartialView("~/Views/Historique/partialDeviceOS.cshtml");
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

        public ActionResult StatsUsage()
        {
            return PartialView("~/Views/Historique/partialStatsUtilisation.cshtml");
        }

        public ActionResult Tops()
        {
            return PartialView("~/Views/Historique/partialTops.cshtml");
        }
    }
}
