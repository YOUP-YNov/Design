﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using YOUP_Design.Classes.Profile;

namespace YOUP_Design.Models.Profile
{
    public static class AcceptFriendAPIConnecteur
    {
        public static readonly string urlAction = "api/AcceptFriend/";

        public static async Task<IEnumerable<UtilisateurSmall>> Get(int id)
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
                    return await response.Content.ReadAsAsync<IEnumerable<UtilisateurSmall>>();
                }
                return null;
            }
        }

        public static async Task<bool> Post(int utilisateur_id, int ami_id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ProfileConstantes.UrlAPIProfile);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PostAsJsonAsync(urlAction + "?utilisateur_id=" + utilisateur_id + "&friend_id=" + ami_id, new object());
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<bool>();
                }
                return false;
            }
        }

    }
}