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
using YOUP_Design.Models.Evenement;
using YOUP_Design.Models.Profile;
using RestSharp;
using Service.Evenement.ExpositionAPI.Models.ModelCreate;
using YOUP_Design.WebApi.Evenement;
using System.Net;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace YOUP_Design.Controllers
{
    public class EvenementsController : Controller
    {
        string ApiEvenement = System.Configuration.ConfigurationManager.AppSettings["ApiEvenement"];

        public async Task<bool> setEvent(EventCreation e, int id_utilisateur, Guid token)
        {
            string[] adr = e.Adresse.Split(',');

            decimal lat;
            Decimal.TryParse(e.Latitude, NumberStyles.Float, CultureInfo.InvariantCulture,  out lat);
            decimal lon;
            Decimal.TryParse(e.Longitude, NumberStyles.Float, CultureInfo.InvariantCulture, out lon);

            CustomEvenementCreate customEvent = new CustomEvenementCreate()
            {
                evenement = new EvenementCreate()
                {
                    Categorie = new EvenementCategorieFront() { Id = e.Categorie },
                    TitreEvenement = e.TitreEvenement,
                    DescriptionEvenement = e.DescriptionEvenement,
                    DateEvenement = new DateTime(e.DateEvenement.Year, e.DateEvenement.Month, e.DateEvenement.Day, e.Heure.Hour, e.Heure.Minute, 0),
                    MaximumParticipant = e.MaximumParticipant,
                    MinimumParticipant = 0,
                    Price = e.Prix,
                    Premium = false,
                    Payant = e.Prix > 0,
                    DateFinInscription = e.DateFinInscription,
                    //Public = e.Public,
                    //HashTag = e.MotsCles.Split(','),
                    Public = true,
                    HashTag = new List<string>(),
                    EventAdresse = new EventLocationFront()
                    {
                        Adresse = adr[0],
                        Ville = adr[1],
                        CodePostale = "33300",
                        Pays = "France",
                        Latitude = lat,
                        Longitude = lon,
                        Nom = string.Empty
                    },
                    Galleries = new List<EventImageFront>()
                        {
                            new EventImageFront()
                            {
                                Url = e.ImageUrl
                            }
                        }
                },
                friends = new List<long>()
            };

            //WebClient client = new WebClient();
            //client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            //string json = JsonConvert.SerializeObject(customEvent);
            //try
            //{
            //    string result = client.UploadString(ApiEvenement + "api/Evenement?token=" + token.ToString(), "=" + json);
            //}
            //catch (WebException)
            //{
            //    return false;
            //}
            //return true;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiEvenement);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PostAsJsonAsync("api/Evenement?token=" + token.ToString(), customEvent);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }


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
        public ActionResult Index()
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
            ViewBag.region = getRegion();
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

            foreach (var date in dates)
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
            }
            else if (date == "Plus tard ...")
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
            ViewBag.listeCategorie = webApiEvenementController.getCategorie();
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Creation(EventCreation model)
        {
            if (ModelState.IsValid)
            {
                var u = ProfileCookie.GetCookie(HttpContext);
                if (u == null)
                {
                    ViewBag.listeCategorie = webApiEvenementController.getCategorie();
                    ModelState.AddModelError(string.Empty, "Vous devez être connecté pour créer un événement");
                    return View(model);
                }

                if (model.DateEvenement < DateTime.Now.Date)
                    ModelState.AddModelError(string.Empty, "La date de l'évènement doit être superieure à la date d'aujourd'hui");
                if (model.DateFinInscription > model.DateEvenement)
                    ModelState.AddModelError(string.Empty, "La date de fin d'inscription doit être inférieure à la date de l'évènement");
                
                if(ModelState.IsValid && await setEvent(model, u.Utilisateur_Id, u.Token))
                {
                    return RedirectToAction("Index", "Evenements");
                }
            }

            ViewBag.listeCategorie = webApiEvenementController.getCategorie();
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
