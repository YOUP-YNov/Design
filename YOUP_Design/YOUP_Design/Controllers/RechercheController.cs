﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestSharp;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YOUP_Design.Classes.Recherche;
using YOUP_Design.Classes.Profile;
using YOUP_Design.Models.Evenement.webApiObjects;

namespace YOUP_Design.Controllers
{
    public class RechercheController : Controller
    {
        public T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient("http://youp-recherche.azurewebsites.net/");
            var response = client.Execute<T>(request);
            return response.Data;
        }
        public T ExecuteUser<T>(RestRequest request) where T : new()
        {
            var client = new RestClient("http://aspmoduleprofil.azurewebsites.net/");
            var response = client.Execute<T>(request);
            return response.Data;
        }
        public T ExecuteEvent<T>(RestRequest request) where T : new()
        {
            var client = new RestClient("http://youp-evenementapi.azurewebsites.net/");
            var response = client.Execute<T>(request);
            return response.Data;
        }
        public RechercheGenerique GetRecherche(string keyword)
        {
            var request = new RestRequest("search/get?keyword=" + keyword, Method.GET);
            var result = Execute<RechercheGenerique>(request);
            return result;
        }

        public Utilisateur GetUser(int id)
        {
            var request = new RestRequest("api/User/" + id, Method.GET);
            var result = ExecuteUser<Utilisateur>(request);
            return result;
        }

        public EvenementTimelineFront GetEvents(int id)
        {
            var request = new RestRequest("api/Evenement/" + id, Method.GET);
            var result = ExecuteEvent<EvenementTimelineFront>(request);
            return result;
        }

        //
        // GET: /Recherche/
        public ActionResult Index(string keyword)
        {
            if (keyword == null)
            {
                keyword = "";
            }
            RechercheGenerique results = new RechercheGenerique();
            results = this.GetRecherche(keyword);

            List<Utilisateur> users = new List<Utilisateur>();
            if (results.Gprofile != null)
            {
                foreach (var user in results.Gprofile)
                {
                    try
                    {
                        users.Add(GetUser(Convert.ToInt32(user._source.Id)));
                    }
                    catch (Exception)
                    {

                    }

                }
            }
            ViewBag.usersResults = users;
            
            List<EvenementTimelineFront> events = new List<EvenementTimelineFront>();
            if (results.Gevent != null)
            {
                foreach (var youpevent in results.Gevent)
                {
                    try
                    {
                        events.Add(GetEvents(Convert.ToInt32(youpevent._source.Id)));
                    }
                    catch (Exception)
                    {

                    }

                }
            }
            ViewBag.eventsResults = events;

            return View();
        }
    }
}
