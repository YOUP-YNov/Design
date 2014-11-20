using Newtonsoft.Json;
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
        private static string _UrlWebAPi = "http://youphistorique-wepapi.apphb.com/";
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
    }
}