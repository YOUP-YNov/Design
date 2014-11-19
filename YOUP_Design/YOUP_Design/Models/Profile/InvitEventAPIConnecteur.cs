using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace YOUP_Design.Models.Profile
{
    public static class InvitEventAPIConnecteur
    {
        public static readonly string urlAction = "api/InvitEvent";
        public static async Task<bool> Post(int event_id, int user_id, int invit_id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ProfileConstantes.UrlAPIProfile);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PostAsJsonAsync(urlAction + "?event_id=" + event_id + "&user_id=" + user_id + "&invit_id=" + invit_id, new object());
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
    }
}