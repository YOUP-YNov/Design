using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YOUP_Design.Classes.Blog;
using YOUP_Design.Models.Blog;

namespace YOUP_Design.Controllers
{
    public class BlogController : Controller
    {
        //
        // GET: /Blog/

        public async Task<ActionResult> Index()
        {
            List<Blog> blogs = new List<Blog>();
            await GetBlogsAsync(blogs);
            return View(blogs);

        }

        static async Task GetBlogsAsync(List<Blog> list)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://youp-blog.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/blog");

                if (response.IsSuccessStatusCode)
        {
                    list = await response.Content.ReadAsAsync<List<Blog>>();
                }
            }
        }

        public ActionResult ModComment()
        {
            return View();
        }

        public ActionResult PubBlog()
        {
            return View();
        }

        public ActionResult Blog_edit()
        {
            return View();
        }

        public ActionResult Blog_article_edit()
        {
            return View();
        }

        public ActionResult Blog_liste_article()
        {
            return View();
        }

        public ActionResult Blog_vue()
        {
            return View();
        }

        public ActionResult Blog_voir_plus()
        {
            return View();
        }

        //
        // GET: /Blog/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // POST: /Blog/Create
        [HttpPost]
        public ActionResult Create(BlogModel model)
        {
            try
            {
                Blog blog = new Blog() { TitreBlog = model.TitreBlog, Actif = true, Categorie_id = model.CategorieId, Promotion = false, DateCreation = DateTime.Now, Theme_id = model.ThemeId};
                //httpclient (voir msdn)
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        //
        // POST: /Blog/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, BlogModel model)
        {
            try
            {
                Blog blog = new Blog() {Blog_id = id, TitreBlog = model.TitreBlog, Actif = true, Categorie_id = model.CategorieId, Promotion = false, DateCreation = DateTime.Now, Theme_id = model.ThemeId };
                //httpclient (voir msdn)
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Blog/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Blog/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
