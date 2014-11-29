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

        public async Task<ActionResult> Detail(int id)
        {

            var u = await UserPublicAPIConnecteur.Get(id);

            if (u == null)

                return RedirectToAction("Index", "Home");

            return View(u);

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
                    return RedirectToAction("Index", "Profile");
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
        public async Task<ActionResult> Create(UtilisateurInscriptModelBinding model)
        {
            if(ModelState.IsValid)
            {
                var u = await UserAPIConnecteur.Post(new Utilisateur()
                {
                    Pseudo = model.Pseudo,
                    Prenom = model.Prenom,
                    Nom = model.Nom,
                    MotDePasse = model.Password,
                    Ville = model.Ville,
                    CodePostal = model.CodePostal,
                    AdresseMail = model.Email,
                    DateNaissance = model.DateNaissance.AddHours(12), // pour ne pas avoir -1j au format EN
                    DateInscription = DateTime.Now,
                    Categories = new List<Categorie>(),
                    Amis = new List<UtilisateurSmall>(),
                    Actif = true,
                    Sexe = true,
                    Partenaire = false,
                    Metier = "",
                    PhotoChemin = model.PhotoUrl,
                    Situation = "",
                    Presentation = ""
                });
                if(u != null)
                {
                    ProfileCookie.CreateCookie(HttpContext, u);
                    return RedirectToAction("Index", "Profile");
                }
                ViewBag.Error = "Impossible de creer le compte à partir des données renseigné.";
                return View("inscription");
            }
            ViewBag.Error = "Veuillez remplir tout les champs pour créer votre compte.";
            return View("inscription");
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
            return RedirectToAction("Index", "Profile");
        }

        public async Task<ActionResult> DeleteFriend(int idF)
        {
            var u = ProfileCookie.GetCookie(HttpContext);

            if (u != null)
            {
                var f = await FriendAPIConnecteur.Delete(u.Utilisateur_Id, idF);

                if (f != null)
                {
                    return RedirectToAction("Index", "Profile");
                }
                return RedirectToAction("Index", "Profile");
            }

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
