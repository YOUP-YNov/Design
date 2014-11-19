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
            return PartialView("~/Views/Historique/partialStatsUtilisation.cshtml");
        }

        public ActionResult Tops()
        {
            return PartialView("~/Views/Historique/partialTops.cshtml");
        }
    }
}
