using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YOUP_Design.Classes.Profile;
using YOUP_Design.Models.Profile;

namespace YOUP_Design.Controllers
{
    public class ProfileController : Controller
    {
        [YoupAuthorize]
        public ActionResult Index()
        {
            var u = ProfileCookie.GetCookie(HttpContext);
            if (u != null)
                return View(u);
            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModelBinding model)
        {
            if (ModelState.IsValid)
            {
                var u = await AuthAPIConnecteur.Post(model.Email, model.Password);
                if (u != null)
                {
                    ProfileCookie.CreateCookie(HttpContext, u);
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.Error = "Email / Mot de passe incorrect";
            }
            else
                ViewBag.Error = "Veuillez saisir votre Email et votre mot de passe.";
            return View();
        }

        public async Task<ActionResult> Create()
        {
            return View("inscription");
        }


        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
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

        [YoupAuthorize]
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        [YoupAuthorize]
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
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

        public async Task<ActionResult> Logout()
        {
            var u = ProfileCookie.GetCookie(HttpContext);
            if (u != null)
                ProfileCookie.RemoveCookie(HttpContext);
            return RedirectToAction("Index", "Home");
        }

        [YoupAuthorize]
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
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
