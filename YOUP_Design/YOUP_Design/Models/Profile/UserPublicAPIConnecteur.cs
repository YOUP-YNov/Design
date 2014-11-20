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
    public static class UserPublicAPIConnecteur
    {
        public static async Task<UtilisateurPublic> Get(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ProfileConstantes.UrlAPIProfile);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync("api/UserPublic/" + id);
                if (response.IsSuccessStatusCode)
                {
                    return null;
                }
                return null;
            }
        }
    }
}