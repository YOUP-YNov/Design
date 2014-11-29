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
    public static class AuthAPIConnecteur
    {
        public static async Task<Utilisateur> Post(string email, string pass, string device = "")
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ProfileConstantes.UrlAPIProfile);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP POST
                var response = await client.PostAsJsonAsync("api/Auth/?Email=" + email + "&Pass=" + pass+ "&Device=" +device, new object());
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Utilisateur>();
                }
                return null;
            }
        }
        public static async Task<Utilisateur> Get(Guid id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ProfileConstantes.UrlAPIProfile);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP POST
                var response = await client.GetAsync("api/Auth/" + id.ToString());
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Utilisateur>();
                }
                return null;
            }
        }
    }
}