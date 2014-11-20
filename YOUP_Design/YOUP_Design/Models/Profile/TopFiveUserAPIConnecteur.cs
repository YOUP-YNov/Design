using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using YOUP_Design.Classes.Profile;

namespace YOUP_Design.Models.Profile
{
    public static class TopFiveUserAPIConnecteur
    {
        public static readonly string urlAction = "api/TopFiveUser";
        public static async Task<UtilisateurSmall> Get()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ProfileConstantes.UrlAPIProfile);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync(urlAction);
                if (response.IsSuccessStatusCode)
                {
                    return null;
                }
                return null;
            }
        }
    }
}