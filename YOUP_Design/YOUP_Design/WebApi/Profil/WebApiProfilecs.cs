using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using YOUP_Design.Classes.Profile;


namespace YOUP_Design.WebApi.Profile
{
    public class WebApiProfilecs
    {

        /// <summary>
        /// Ajout d'un utilisatreur
        /// </summary>
        /// <param name="NewUser">Class Utilisataur</param>
        /// <returns>Un message en cas de succès</returns>
        public async Task PostUser(Utilisateur NewUser)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://aspmoduleprofil.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Envois des données
                HttpResponseMessage reponse = await client.PutAsJsonAsync<Utilisateur>("api/User", NewUser);
                if (reponse.IsSuccessStatusCode) { Console.WriteLine("L'utilisateur a bien été crée"); }
            }
        }

        /// <summary>
        /// Récuperer les informations d'un utilisateur
        /// </summary>
        /// <param name="userId">Identifient (par un id) de l'utilisateur</param>
        /// <returns></returns>
        public async Task GettUser(Int32 userId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://aspmoduleprofil.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Récupération des données
                HttpResponseMessage reponse = await client.GetAsync("api/User/" + userId + "");
                if (reponse.IsSuccessStatusCode) { Console.WriteLine("L'utilisateur a bien été récupéré"); }
            }
        }
    }
}