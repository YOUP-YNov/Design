using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace YOUP_Design.Controllers
{
    public class EvenementsController : Controller
    {
        //
        // GET: /Evenement/
        public  ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Evenement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Evenement/Create

        public ActionResult Creation()
        {
            return View();
        }

        //
        // POST: /Evenement/Create

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

        //
        // GET: /Evenement/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Evenement/Edit/5

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
        // GET: /Evenement/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Evenement/Delete/5

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
