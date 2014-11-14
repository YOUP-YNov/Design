using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YOUP_Design.Controllers
{
    public class HistoriqueController : Controller
    {
        //
        // GET: /Historique/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Historique/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Historique/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Historique/Create

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
        // GET: /Historique/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Historique/Edit/5

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
        // GET: /Historique/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Historique/Delete/5

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
