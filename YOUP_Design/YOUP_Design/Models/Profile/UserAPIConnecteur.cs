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
    public static class UserAPIConnecteur
    {
        public static async Task<Utilisateur> Get(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ProfileConstantes.UrlAPIProfile);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync("api/User/" + id);
                if (response.IsSuccessStatusCode)
                {
                    return null;
                }
                return null;
            }
        }

        public static async Task<Utilisateur> Put(Utilisateur utilisateur)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ProfileConstantes.UrlAPIProfile);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PutAsJsonAsync("api/User/", utilisateur);
                if (response.IsSuccessStatusCode)
                {
                    return null;
                }
                return null;
            }
        }

        public static async Task<Utilisateur> Post(Utilisateur utilisateur)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ProfileConstantes.UrlAPIProfile);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PostAsJsonAsync("api/User/", utilisateur);
                if (response.IsSuccessStatusCode)
                {
                    return null;
                }
                return null;
            }
        }

        public static async Task<bool> Delete(int id_user)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ProfileConstantes.UrlAPIProfile);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.DeleteAsync("api/User/" + id_user);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
    }
}