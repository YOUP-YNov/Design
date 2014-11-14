using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Blog_vue()
        {
            return View("Blog_vue");
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
