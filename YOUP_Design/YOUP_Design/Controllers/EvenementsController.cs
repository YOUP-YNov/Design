using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using YOUP_Design.Models.Evenement.webApiObjects;
using YOUP_Design.Models.Evenement.templatesObjects;
using YOUP_Design.Classes.Evenement;
using RestSharp;
using YOUP_Design.Models.Evenement;
using YOUP_Design.Models.Profile;

namespace YOUP_Design.Controllers
{
    public class EvenementsController : Controller
    {

        public T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient("http://youp-evenementapi.azurewebsites.net/");
            var response = client.Execute<T>(request);
            return response.Data;
        }

        public void setEvent(EventCreation e, int id_utilisateur, Guid token)
        {
            var request = new RestRequest("api/Evenement?token="+token.ToString(), Method.POST);
            string[] adr = e.Adresse.Split(',');

            decimal lat;
            Decimal.TryParse(e.Latitude, out lat);
            decimal lon;
            Decimal.TryParse(e.Longitude, out lon);

            var ev = new EvenementFront()
            {
                TitreEvenement = e.TitreEvenement,
                DescriptionEvenement = e.DescriptionEvenement,
                DateEvenement = e.DateEvenement,
                CreateDate = DateTime.Now,
                MaximumParticipant = e.MaximumParticipant,
                Price = e.Prix,
                Payant = e.Prix > 0,
                Public = e.Public,
                HashTag = e.MotsCles.Split(','),
                EventAdresse = new EventLocationFront()
                {
                    Adresse = adr[0],
                    Ville = adr[1],
                    Pays = "France",
                    Latitude = lat,
                    Longitude = lon
                },
                OrganisateurId = id_utilisateur,
                Galleries = new List<EventImageFront>()
                {
                    new EventImageFront()
                    {
                        Url = e.ImageUrl
                    }
                }
            };

            request.AddParameter("evenement", ev);
            request.AddParameter("evenement", ev);

            Execute<EventCreation>(request);

        }

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
