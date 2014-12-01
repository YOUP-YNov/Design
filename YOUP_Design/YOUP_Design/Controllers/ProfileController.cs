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
        public async  Task<ActionResult> Index()
        {
            var u = ProfileCookie.GetCookie(HttpContext);

            ViewBag.AcceptFriendRequest = await AcceptFriendAPIConnecteur.Get(u.Utilisateur_Id);


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
                    return RedirectToAction("Index", "Evenements");
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
        public async Task<ActionResult> Edit(FormCollection collection)
        {
            var u = ProfileCookie.GetCookie(HttpContext);
            
            string nom = collection.Get("Nom");
            string prenom = collection.Get("Prenom");
            string pseudo = collection.Get("Pseudo");
            DateTime DateNaisse = DateTime.Parse(collection.Get("DateNaissance"));
            string ville = collection.Get("Ville");
            string codepostal = collection.Get("CodePostal");
            string motdepasse = collection.Get("Password");
            if (!string.IsNullOrEmpty(nom))
                u.Nom = nom;
            if (!string.IsNullOrEmpty(prenom))
                u.Prenom = prenom;
            if (!string.IsNullOrEmpty(pseudo))
                u.Pseudo = pseudo;
            if (!string.IsNullOrEmpty(ville))
                u.Ville = ville;
            if (!string.IsNullOrEmpty(codepostal))
                u.CodePostal = codepostal;
            if (DateNaisse != null)
                u.DateNaissance = DateNaisse.AddHours(12);

            if (motdepasse != "default")
                u.MotDePasse = Encrypt.hashSHA256(motdepasse);

            var nu = await UserAPIConnecteur.Put(u);
            if(nu != null)
            {
                ProfileCookie.CreateCookie(HttpContext, nu);
            }
            return RedirectToAction("Index", "Profile");
        }

        public async Task<ActionResult> Logout()
        {
            var u = ProfileCookie.GetCookie(HttpContext);
            if (u != null)
                ProfileCookie.RemoveCookie(HttpContext);
            return RedirectToAction("Index", "Profile");
        }

        public async Task UpdatePicture()
        {
            string img = Request.Params.Get("img");
            var u = ProfileCookie.GetCookie(HttpContext);
            if( u != null)
            {
                u.PhotoChemin = img;
                ProfileCookie.CreateCookie(HttpContext, u);
                await UserAPIConnecteur.Put(u);
            }
        }

        public async Task<ActionResult> DeleteFriend(int id)
        {
            var u = ProfileCookie.GetCookie(HttpContext);

            if (u != null)
            {
                var f = await FriendAPIConnecteur.Delete(u.Utilisateur_Id, id);

                if (f)
                {
                    u.Amis.Remove(u.Amis.FirstOrDefault(x => x.Utilisateur_Id == id));
                    ProfileCookie.CreateCookie(HttpContext, u);
                    return RedirectToAction("Index", "Profile");
                }
                return RedirectToAction("Index", "Profile");
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> AddFriendRequest(int id)
        {
            var u = ProfileCookie.GetCookie(HttpContext);

            if (u != null)
            {
                var f = await FriendAPIConnecteur.Post(u.Utilisateur_Id, id);
                if (f)
                {
                    var nu = await AuthAPIConnecteur.Get(u.Token);
                    if (nu != null)
                    {
                        ProfileCookie.CreateCookie(HttpContext, nu);
                        return RedirectToAction("Index", "Profile");
                    }
                }
                return RedirectToAction("Index", "Profile");
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> AcceptFriend(int id)
        {
            var u = ProfileCookie.GetCookie(HttpContext);
            var rep = await AcceptFriendAPIConnecteur.Post(u.Utilisateur_Id, id);
            if(rep)
            {
                var nu = await AuthAPIConnecteur.Get(u.Token);
                if (nu != null)
                {
                    ProfileCookie.CreateCookie(HttpContext, nu);
                    return RedirectToAction("Index", "Profile");
                }
            }
            return RedirectToAction("Index", "Profile");
        }

        public async Task<ActionResult> Delete(int id)
        {
            var d = await UserAPIConnecteur.Delete(id);
            if (d)
            {
                var u = ProfileCookie.GetCookie(HttpContext);
                if (u != null)
                {
                    ProfileCookie.RemoveCookie(HttpContext);
                    return RedirectToAction("Index", "Profile");
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
