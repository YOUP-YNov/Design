using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using YOUP_Design.Models.Evenement.webApiObjects;
using YOUP_Design.Models.Evenement.templatesObjects;
using YOUP_Design.Classes.Evenement;

namespace YOUP_Design.Controllers
{
    public class EvenementsController : Controller
    {
        //
        // GET: /Evenement/
        public  ActionResult Index()
        {
            return View();
        }

        private struct timeLineStruct
        {
            public List<EvenemenDate> liste;
            public string lastDate;
        }

        public JsonResult TimeLine(List<EvenementTimelineFront> listeEvenement)
        {
            var timeLine = transformObjects(listeEvenement);
            return Json(new { timeLine = timeLine });
        }

        private timeLineStruct transformObjects(List<EvenementTimelineFront> listeEvenementApi)
        {
            var result = new List<EvenemenDate>();
            var dates = listeEvenementApi.Select(t => t.DateEvenement.Date).Distinct().ToList();

            var dateString = new List<String>();
            dateString.Add("Aujourd'hui");
            dateString.Add("demain");

            foreach(var date in dates)
            {
                if (date.Date > DateTime.Now.AddDays(7) && date.Date < DateTime.Now.AddDays(14))
                {
                    dateString.Add(string.Format("La semaine prochaine (entre le {0} et le {1})"
                        , DateTime.Now.AddDays(7).ToShortDateString()
                        , DateTime.Now.AddDays(14).ToShortDateString()));
                }
                //on ne veux que les date supérieur à ajourd'hui et demain
                else if (date.Date > DateTime.Now.AddDays(1))
                {
                    dateString.Add(date.ToString());
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
            else if (date == "demain")
            {
                listeEvenementTotransforme = listeEvenementApi.Where(t => t.DateEvenement.Date == DateTime.Now.AddDays(1).Date).ToList();
            }
            else if (date == "La semaine prochaine")
            {
                listeEvenementTotransforme = listeEvenementApi.Where(t => t.DateEvenement.Date > DateTime.Now.AddDays(7).Date).ToList();
            }
            //les dates entre demain et la semaine prochaine
            else
            {
                listeEvenementTotransforme = listeEvenementApi
                    .Where(t => t.DateEvenement.Date.ToString() == date).ToList();
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
        //
        // GET: /Evenement/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.idEvenement = id;
            return View();
        }

        public JsonResult DetailEvenement(EvenementFront listeEvenementApi)
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
