using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using YOUP_Design.Models.Evenement.webApiObjects;

namespace YOUP_Design.WebApiControler
{
    /// <summary>
    /// test de méthode asynchrone 
    /// Obsolete => tout faire en JQUERY !! 
    /// paas le temps de monté en compétence sur l'asynchrone.
    /// </summary>
    public class ApiEvenement
    {
        public async Task getEvenements()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://youp-evenementapi.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Evenement?max_result=" + 20);
                if (response.IsSuccessStatusCode)
                {
                    var evenements = await response.Content.ReadAsAsync<EvenementTimelineFront>();

                    Console.WriteLine("TOTOTOTO");
                }
            }
        }
    }
}