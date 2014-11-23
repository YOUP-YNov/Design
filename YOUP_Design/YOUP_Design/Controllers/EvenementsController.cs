using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using YOUP_Design.Models.Evenement.webApiObjects;
using YOUP_Design.Models.Evenement.templatesObjects;
using YOUP_Design.Classes.Evenement;
using YOUP_Design.Models.Common;
using YOUP_Design.WebApi.Evenement;

namespace YOUP_Design.Controllers
{
    public class EvenementsController : Controller
    {
        string ApiEvenement = System.Configuration.ConfigurationManager.AppSettings["ApiEvenement"];
        
        #region TimeLine
        public struct region
        {
            public string libelle;
            public string dpts;
        }

        public List<region> getRegion()
        {
            var listeRegion = new List<region>();
            foreach (var region in DepartementParRegion.ListeDepartementParRegion)
            {
                var regionAdd = new region();
                regionAdd.libelle = region.Key;
                foreach (var dpt in region.Value)
                {
                    regionAdd.dpts += dpt.ToString() + ";";
                }
                listeRegion.Add(regionAdd);
            }
            return listeRegion;
        }

        //
        // GET: /Evenement/
        public  ActionResult Index()
        {
            ViewBag.apiEvenement = ApiEvenement;
            ViewBag.listeCategorie = webApiEvenementController.getCategorie();

            ViewBag.region = getRegion();
            return View();
        }

        public ActionResult VueParRegion(string region)
        {
            List<int> departements = DepartementParRegion.ListeDepartementParRegion[region];
            ViewBag.listeDepartementToView = departements.ToArray();
            ViewBag.apiEvenement = ApiEvenement;
            ViewBag.listeCategorie = webApiEvenementController.getCategorie();
            return View("Index");
        }

        private struct timeLineStruct
        {
            public List<EvenemenDate> liste;
            public string lastDate;
        }

        [HttpPost]
        public JsonResult TimeLine(List<EvenementTimelineFront> listeEvenement)
        {
            var timeLine = listeEvenement != null ? transformObjects(listeEvenement) : new timeLineStruct();
            return Json(new { timeLine = timeLine });
        }

        private timeLineStruct transformObjects(List<EvenementTimelineFront> listeEvenementApi)
        {
            var result = new List<EvenemenDate>();
            var dates = listeEvenementApi.Select(t => t.DateEvenement.Date).Distinct().ToList();

            var dateString = new List<String>();
            dateString.Add("Aujourd'hui");
            dateString.Add("Demain");

            foreach(var date in dates)
            {
                if (date.Date > DateTime.Now.AddDays(7) && date.Date < DateTime.Now.AddDays(14))
                {
                    var nextWeekString = string.Format("La semaine prochaine (entre le {0} et le {1})"
                        , DateTime.Now.AddDays(7).ToShortDateString()
                        , DateTime.Now.AddDays(14).ToShortDateString());

                    if (!dateString.Contains(nextWeekString))
                    {
                        dateString.Add(nextWeekString);
                    }
                }
                //on ne veux que les date supérieur à ajourd'hui et demain
                else if (date.Date > DateTime.Now.AddDays(1) && date.Date <= DateTime.Now.AddDays(7))
                {
                    dateString.Add(date.ToShortDateString());
                }
            }

            dateString.Add("Plus tard ...");

            foreach (var date in dateString)
            {
                var evtDate = new EvenemenDate();
                evtDate.date = date;

                var listeEvenementTotransforme = EvtParDatePourTimeLine(date, listeEvenementApi);

                //on transforme les Objet venant de l'api en objet à affcher
                var listeTimeLineObjects = listeEvenementTotransforme.Select(t => new evenementTimeLineObject(t)).ToList();
                evtDate.listeEvenements = listeTimeLineObjects;

                result.Add(evtDate);
            }
            var structRetour = new timeLineStruct();

            structRetour.lastDate = DateTime.Now.AddDays(14).ToString("yyyy-MM-dd");
            structRetour.liste = result;
            return structRetour;
        }

        private List<EvenementTimelineFront> EvtParDatePourTimeLine(string date, List<EvenementTimelineFront> listeEvenementApi)
        {
            var listeEvenementTotransforme = new List<EvenementTimelineFront>();
            if (date == "Aujourd'hui")
            {
                listeEvenementTotransforme = listeEvenementApi.Where(t => t.DateEvenement.Date == DateTime.Now.Date).ToList();
            }
            else if (date == "Demain")
            {
                listeEvenementTotransforme = listeEvenementApi.Where(t => t.DateEvenement.Date == DateTime.Now.AddDays(1).Date).ToList();
            }
            else if (date == "La semaine prochaine")
            {
                listeEvenementTotransforme = listeEvenementApi.Where(t => t.DateEvenement.Date > DateTime.Now.AddDays(7).Date && t.DateEvenement.Date < DateTime.Now.AddDays(14).Date).ToList();
            }else if (date == "Plus tard ...")
            {
                listeEvenementTotransforme = listeEvenementApi.Where(t => t.DateEvenement.Date >= DateTime.Now.AddDays(14)).ToList();
            }
            //les dates entre demain et la semaine prochaine
            else
            {
                listeEvenementTotransforme = listeEvenementApi
                    .Where(t => t.DateEvenement.Date.ToShortDateString() == date).ToList();
            }

            return listeEvenementTotransforme;
        }


        public JsonResult GestionScroll(List<EvenementTimelineFront> listeEvenement)
        {
            if (listeEvenement != null)
            {
                var timeLine = listeEvenement.Select(t => new evenementTimeLineObject(t)).ToList();
                return Json(new { timeLine = timeLine });
            }
            else
            {
                return Json("");
            }
        }
        
        #endregion
        //
        // GET: /Evenement/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.apiEvenement = ApiEvenement;
            ViewBag.idEvenement = id;
            return View();
        }

        public JsonResult DetailEvenement(EvenementTimelineFront listeEvenementApi)
        {
            var result = new evenementTimeLineObject(listeEvenementApi);
            return Json(result);
        }

        //
        // GET: /Evenement/Create

        public ActionResult Creation()
        {
            return View();
        }

        //
        // POST: /Evenement/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Evenement/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Evenement/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Evenement/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Evenement/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
