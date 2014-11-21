using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YOUP_Design.Classes.Blog;
using YOUP_Design.Models.Evenement.webApiObjects;
using YOUP_Design.Classes.Profile;
using YOUP_Design.Classes.Historique;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestSharp;

namespace YOUP_Design.Controllers
{
    public class HomeController : Controller
    {
        public T ProfilRequest<T>(RestRequest request) where T : new()
        {
            var client = new RestClient("http://aspmoduleprofil.azurewebsites.net/");
            var response = client.Execute<T>(request);
            return response.Data;
        }

        public T EventRequest<T>(RestRequest request) where T : new()
        {
            var client = new RestClient("http://youp-evenementapi.azurewebsites.net/");
            var response = client.Execute<T>(request);
            return response.Data;
        }

        public T BlogRequest<T>(RestRequest request) where T : new()
        {
            var client = new RestClient("http://youp-blog.azurewebsites.net/");
            var response = client.Execute<T>(request);
            return response.Data;
        }

        public T HistoriqueRequest<T>(RestRequest request) where T : new()
        {
            var client = new RestClient("http://youp-evenementapi.azurewebsites.net/");
            var response = client.Execute<T>(request);
            return response.Data;
        }


        public List<UtilisateurSmall> GetLastProfiles()
        {
            var request = new RestRequest("api/TopTenUser", Method.GET);
            var result = ProfilRequest<List<UtilisateurSmall>>(request);
            return result;
        }

        public List<EvenementTimelineFront> GetLastEvents()
        {
            var request = new RestRequest("api/Evenement?max_result=3", Method.GET);
            var result = EventRequest<List<EvenementTimelineFront>>(request);
            return result;
        }

        public ActionResult Index()
        {
            //Derniers Utilisateurs
            List<UtilisateurSmall> profiles = new List<UtilisateurSmall>();
            List<UtilisateurSmall> lastprofiles = new List<UtilisateurSmall>();
            profiles = this.GetLastProfiles();
            int count = 0;

            foreach (UtilisateurSmall profil in profiles)
            {
                if (count < 4)
                {
                    lastprofiles.Add(profil);
                }

                count++;
            }

            ViewBag.LastProfiles = lastprofiles;

            //Derniers Evenements
            List<EvenementTimelineFront> events = new List<EvenementTimelineFront>();
            events = this.GetLastEvents();

            ViewBag.LastEvents = events;

            return View();
        }
    }
}
