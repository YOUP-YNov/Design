﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using YOUP_Design.Classes.Profile;

namespace YOUP_Design.Models.Profile
{
    public static class CategorieAPIConnecteur
    {
        private static readonly string urlAction = "api/Categorie/";
        public static async Task<Categorie> GetCategorie(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ProfileConstantes.UrlAPIProfile);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync(urlAction + id);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Categorie>();
                }
                return null;
            }
        }

        public static async Task<List<Categorie>> Post(Categorie categorie, Guid token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ProfileConstantes.UrlAPIProfile);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PostAsJsonAsync(urlAction + "?token=" + token, categorie);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<Categorie>>();
                }
                return null;
            }
        }

        public static async Task<bool> Delete(int categorie_id, Guid token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ProfileConstantes.UrlAPIProfile);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.DeleteAsync(urlAction + "?token=" + token + "&categori_id="  +categorie_id);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<bool>();
                }
                return false;
            }
        }
    }
}