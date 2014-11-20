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
        /// <summary>
        /// appel à la méthode PutEvenement de la webApi evenement
        /// </summary>
        /// <param name="evenement">contient un evenement et une liste d'id des amis à invité pour l'évenement</param>
        public async void PutEvent(EvenementCreate evenement)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://youp-evenementapi.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                
                HttpResponseMessage response = await client
                    .PostAsJsonAsync<EvenementCreate>("api/Evenement", evenement);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("ajout de l'évènement");
                }
            }
        }
    }
}