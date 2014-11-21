using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YOUP_Design.Classes.Blog;
using YOUP_Design.Models.Evenement.webApiObjects;
using YOUP_Design.Classes.Profile;
using YOUP_Design.Classes.Historique;
using YOUP_Design.WebApi.Historique;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestSharp;

namespace YOUP_Design.Controllers
{
    public class HomeController : Controller
    {
        public T ProfilRequest<T>(RestRequest request) where T : new()
        {
            var client = new RestClient("http://aspmoduleprofil.azurewebsites.net/");
            var response = client.Execute<T>(request);
            return response.Data;
        }

        public T EventRequest<T>(RestRequest request) where T : new()
        {
            var client = new RestClient("http://youp-evenementapi.azurewebsites.net/");
            var response = client.Execute<T>(request);
            return response.Data;
        }

        public T BlogRequest<T>(RestRequest request) where T : new()
        {
            var client = new RestClient("http://youp-blog.azurewebsites.net/");
            var response = client.Execute<T>(request);
            return response.Data;
        }



        public List<UtilisateurSmall> GetLastProfiles()
        {
            var request = new RestRequest("api/TopTenUser", Method.GET);
            var result = ProfilRequest<List<UtilisateurSmall>>(request);
            return result;
        }

        public List<EvenementTimelineFront> GetLastEvents()
        {
            var request = new RestRequest("api/Evenement?max_result=3", Method.GET);
            var result = EventRequest<List<EvenementTimelineFront>>(request);
            return result;
        }

        public List<Classes.Blog.Blog> GetBlogs()
        {
            var request = new RestRequest("api/blog", Method.GET);
            var result = BlogRequest<List<Classes.Blog.Blog>>(request);
            return result;
        }

        public List<Classes.Blog.Categorie> GetBlogsCategories()
        {
            var request = new RestRequest("api/Categories", Method.GET);
            var result = BlogRequest<List<Classes.Blog.Categorie>>(request);
            return result;
        }

        public ActionResult Index()
        {
            //Derniers Utilisateurs
            List<UtilisateurSmall> profiles = new List<UtilisateurSmall>();
            List<UtilisateurSmall> lastprofiles = new List<UtilisateurSmall>();
            List<UtilisateurSmall> lastprofiles2 = new List<UtilisateurSmall>();
            profiles = this.GetLastProfiles();
            
            int count = 0;
            if (profiles != null)
            {
                foreach (UtilisateurSmall profil in profiles)
                {
                    if (count < 4)
                    {
                        lastprofiles.Add(profil);
                    }
                    else if (count >= 4 && count < 8)
                    {
                        lastprofiles2.Add(profil);
                    }
                    else
                    {
                        break;
                    }

                    count++;
                }
            }
            

            ViewBag.LastProfiles = lastprofiles;
            ViewBag.LastProfiles2 = lastprofiles2;

            //Derniers Evenements
            List<EvenementTimelineFront> events = new List<EvenementTimelineFront>();
            events = this.GetLastEvents();
            if (events == null)
            {
                ViewBag.LastEvents = new List<EvenementTimelineFront>();
            }
            else
            {
                ViewBag.LastEvents = events;
            }
            //Derniers Blogs
            List<Classes.Blog.Blog> blogs = new List<Classes.Blog.Blog>();
            List<Classes.Blog.Blog> lastblogs = new List<Classes.Blog.Blog>();
            
            blogs = this.GetBlogs();
            count = 0;
            if (blogs != null)
            {
                foreach (Blog blog in blogs)
                {
                    if (count < 8)
                    {
                        lastblogs.Add(blog);
                    }
                    else
                    {
                        break;
                    }

                    count++;
                }
            }

            ViewBag.LastBlogs = lastblogs;

            //Tops
            ViewBag.TopAmis = WebApiHistoriqueController.GetTopAmis();
            ViewBag.TopEvents = WebApiHistoriqueController.GetTopEvenementCree();
            ViewBag.TopParticipe = WebApiHistoriqueController.GetTopEvenementParticipe();


            return View();

        }
    }
}
