using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using YOUP_Design.Classes.Evenement.webApiObjects;
using YOUP_Design.Models.Evenement.webApiObjects;

namespace YOUP_Design.WebApi.Evenement
{
    public class webApiEvenementController
    {
        public async void PutEvent(EvenementCreate evenement)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://youp-evenementapi.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client
                    .PutAsJsonAsync<EvenementCreate>("api/Evenement", evenement);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("ajout de l'évènement");
                }
            }
        }
    }
}