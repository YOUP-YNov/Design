﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using YOUP_Design.Models.Evenement.webApiObjects;
using YOUP_Design.Models.Evenement.templatesObjects;
using YOUP_Design.Classes.Evenement;
using YOUP_Design.Models.Common;
using YOUP_Design.Models.Evenement;
using YOUP_Design.Models.Profile;
using RestSharp;
using Service.Evenement.ExpositionAPI.Models.ModelCreate;

namespace YOUP_Design.Controllers
{
    public class EvenementsController : Controller
    {
        string ApiEvenement = System.Configuration.ConfigurationManager.AppSettings["ApiEvenement"];

        public T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient("http://youp-evenementapi.azurewebsites.net/");
            var response = client.Execute<T>(request);
            return response.Data;
        }

        public void setEvent(EventCreation e, int id_utilisateur, Guid token)
        {
            var request = new RestRequest("api/Evenement?token=" + token.ToString(), Method.POST);
            string[] adr = e.Adresse.Split(',');

            decimal lat;
            Decimal.TryParse(e.Latitude, out lat);
            decimal lon;
            Decimal.TryParse(e.Longitude, out lon);

            var evenement = new EvenementCreate()
            {
                TitreEvenement = e.TitreEvenement,
                DescriptionEvenement = e.DescriptionEvenement,
                DateEvenement = e.DateEvenement,
                MaximumParticipant = e.MaximumParticipant,
                Price = e.Prix,
                Payant = e.Prix > 0,
                Public = e.Public,
                HashTag = e.MotsCles.Split(','),
                EventAdresse = new EventLocationFront()
                {
                    Adresse = adr[0],
                    Ville = adr[1],
                    CodePostale = "33300",
                    Pays = "France",
                    Latitude = lat,
                    Longitude = lon
                },
                Galleries = new List<EventImageFront>()
                    {
                        new EventImageFront()
                        {
                            Url = e.ImageUrl
                        }
                    }
            };

            var friends = new List<long>();

            request.AddParameter("", evenement);
            request.AddParameter("", friends);

            Execute<EventCreation>(request);

        }

        //
        // GET: /Evenement/
        public  ActionResult Index()
        {
            ViewBag.apiEvenement = ApiEvenement;
            return View();
        }

        public ActionResult VueParRegion(string region)
        {
            List<int> departements = DepartementParRegion.ListeDepartementParRegion[region];
            ViewBag.listeDepartementToView = departements.ToArray();
            ViewBag.apiEvenement = ApiEvenement;
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

        
        [HttpPost]
        public ActionResult Creation(EventCreation model)
        {
            if(ModelState.IsValid)
            {
                var u = ProfileCookie.GetCookie(HttpContext);
                if(u == null)
                {
                    ViewBag.Error = "Vous devez être authentifié.";
                    return View(model);
                }
                setEvent(model, u.Utilisateur_Id, u.Token);

                return RedirectToAction("Index", "Evenements");
            }

            ViewBag.Error = "Veuillez remplir tous les champs.";

            return View(model);
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
