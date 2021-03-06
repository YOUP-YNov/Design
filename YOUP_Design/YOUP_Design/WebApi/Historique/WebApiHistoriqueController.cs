﻿using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using YOUP_Design.Classes.Historique;

namespace YOUP_Design.WebApi.Historique
{
    public class WebApiHistoriqueController
    {
        private static string _UrlWebAPi = System.Configuration.ConfigurationManager.AppSettings["ApiHistorique"];
        public static List<Utilisateur> GetUtilisateurs()
        {
            var users = new List<Utilisateur>();
 
            WebClient wc = new WebClient();
            string json = wc.DownloadString(string.Concat(_UrlWebAPi, "/api/utilisateur"));

            users = JsonConvert.DeserializeObject<List<Utilisateur>>(json);
            return users;
        }

        public static List<Utilisateur> GetTopAmis()
        {
            var users = new List<Utilisateur>();

            WebClient wc = new WebClient();
            string json = wc.DownloadString(string.Concat(_UrlWebAPi, "/api/utilisateur/TopAmis/5"));

            users = JsonConvert.DeserializeObject<List<Utilisateur>>(json);
            return users;
        }

        public static List<Utilisateur> GetTopEvenementCree()
        {
            var users = new List<Utilisateur>();

            WebClient wc = new WebClient();
            string json = wc.DownloadString(string.Concat(_UrlWebAPi, "/api/utilisateur/TopEventCree/5"));

            users = JsonConvert.DeserializeObject<List<Utilisateur>>(json);
            return users;
        }

        public static List<Utilisateur> GetTopEvenementParticipe()
        {
            var users = new List<Utilisateur>();

            WebClient wc = new WebClient();
            string json = wc.DownloadString(string.Concat(_UrlWebAPi, "/api/utilisateur/TopEventParticipe/5"));

            users = JsonConvert.DeserializeObject<List<Utilisateur>>(json);
            return users;
        }

        public static List<YOUP_Design.Classes.Historique.Evenement> GetEvenementParSaisonalite(string dateDebut, string dateFin)
        {
            var events = new List<YOUP_Design.Classes.Historique.Evenement>();

            WebClient wc = new WebClient();
            string json = wc.DownloadString(string.Concat(_UrlWebAPi, "/api/evenement/EvenementParSaisonalite/", dateDebut, "/", dateFin));

            events = JsonConvert.DeserializeObject<List<YOUP_Design.Classes.Historique.Evenement>>(json);
            return events;
        }

        public static List<Utilisateur> GetTops()
        {
            var users = new List<Utilisateur>();
            users = GetTopAmis();
            users.AddRange(GetTopEvenementCree());          
            return users;
        }

        public static Utilisateur GetUtilisateurByPseudo(string pseudo)
        {
            var user = new Utilisateur();

            WebClient wc = new WebClient();
            string json = wc.DownloadString(string.Concat(_UrlWebAPi, "/api/utilisateur/",pseudo));

            user = JsonConvert.DeserializeObject<Utilisateur>(json);
            return user;
        }

        public static List<YOUP_Design.Classes.Historique.Evenement> GetEvenementParticipeByUser(int userId)
        {
            var evenements = new List<YOUP_Design.Classes.Historique.Evenement>();
            string json = string.Empty;
            WebClient wc = new WebClient();
            try
            {
                json = wc.DownloadString(string.Concat(_UrlWebAPi, "/api/utilisateur/", userId, "/EvenementsParticipes"));
                evenements = JsonConvert.DeserializeObject<List<YOUP_Design.Classes.Historique.Evenement>>(json);
            }
            catch (Exception ex)
            {

            }
            return evenements;
        }

        //[Route("{userId}/EvenementsParticipes")]
        //public List<Evenement> GetEvenementsParticipes(int userId)
        //{
        //    var evenements = _historiqueApiServiceService.GetEvenementParticipeByUserId(userId).ToList();

        //    return evenements;
        //}

        public static List<PageVisitee> GetPageVisitee(string dateDebut,string dateFin)
        {
            var pages = new List<PageVisitee>();
            string json = string.Empty;
            WebClient wc = new WebClient();
            try
            {
                json = wc.DownloadString(string.Concat(_UrlWebAPi, "/api/analytics/views/pages?startDate=",dateDebut,"&endDate=",dateFin));
                pages = JsonConvert.DeserializeObject<List<PageVisitee>>(json);
            }
            catch(Exception ex)
            {

            }
            return pages;
        }
        public static List<DeviceTypeStatRow> GetDeviceType(string dateDebut, string dateFin)
        {
            var pages = new List<DeviceTypeStatRow>();
            string json = string.Empty;
            WebClient wc = new WebClient();
            try
            {
                json = wc.DownloadString(string.Concat(_UrlWebAPi, "api/analytics/views/os?startDate=", dateDebut, "&endDate=", dateFin));
                pages = JsonConvert.DeserializeObject<List<DeviceTypeStatRow>>(json);
            }
            catch (Exception ex)
            {

            }
            return pages;
        }
        public static List<DeviceCategoryStatRow> GetDeviceCategorie(string dateDebut, string dateFin)
        {
            var pages = new List<DeviceCategoryStatRow>();
            string json = string.Empty;
            WebClient wc = new WebClient();
            try
            {
                json = wc.DownloadString(string.Concat(_UrlWebAPi, "api/analytics/views/deviceCategory?startDate=", dateDebut, "&endDate=", dateFin));                
                pages = JsonConvert.DeserializeObject<List<DeviceCategoryStatRow>>(json);
            }
            catch (Exception ex)
            {

            }
            return pages;
        }
    }
}