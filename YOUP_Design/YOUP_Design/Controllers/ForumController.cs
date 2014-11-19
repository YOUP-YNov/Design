using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YOUP_Design.Models.Forum;

namespace YOUP_Design.Controllers
{
    public class ForumController : Controller
    {
        //
        // GET: /Forum/

        public ActionResult Index()
        {
            List<CategorieModel> test = new List<CategorieModel>();
            ViewBag.listeCategorie = test;
            return View();
        }

        //
        // GET: /Forum/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Forum/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Forum/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ViewForum()
        {
            //try
            //{
            //    // TODO: Add insert logic here

            //    return RedirectToAction("Forum");
            //}
            //catch
            //{
            //    return View();
            //}
            return View("ViewForum");
        }

        public ActionResult Discussion()
        {
            //try
            //{
            //    // TODO: Add insert logic here

            //    return RedirectToAction("Forum");
            //}
            //catch
            //{
            //    return View();
            //}
            return View("Discussion");
        }


        //
        // GET: /Forum/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Forum/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Forum/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Forum/Delete/5

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
