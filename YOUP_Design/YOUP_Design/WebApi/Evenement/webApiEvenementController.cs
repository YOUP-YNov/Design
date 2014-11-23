using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using YOUP_Design.Classes.Evenement;
using YOUP_Design.Classes.Evenement.webApiObjects;
using YOUP_Design.Models.Evenement.webApiObjects;

namespace YOUP_Design.WebApi.Evenement
{
    public class webApiEvenementController
    {
        private static string _apiEvenement = System.Configuration.ConfigurationManager.AppSettings["ApiEvenement"];

        public static List<EvenementCategorieFront> getCategorie ()
        {
            WebClient wc = new WebClient();
            string json = wc.DownloadString(string.Concat(_apiEvenement, "/Categories"));
            List<EvenementCategorieFront> result = new List<EvenementCategorieFront>();
            result.AddRange(JsonConvert.DeserializeObject<List<EvenementCategorieFront>>(json));
            return result;
        }
    }
}