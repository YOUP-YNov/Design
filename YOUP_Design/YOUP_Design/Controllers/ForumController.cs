using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YOUP_Design.Classes.Forum;
using YOUP_Design.Models.Forum;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestSharp;

namespace YOUP_Design.Controllers
{
    public class ForumController : Controller
    {
        //
        // GET: /Forum/


        public T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient("http://forumyoup.apphb.com/");
            var response = client.Execute<T>(request);
            return response.Data;
        }


        public List<Forum> GetForums()
        {
            var request = new RestRequest("api/Forums", Method.GET);
            var result = Execute<List<Forum>>(request);

            return result;

        }

        public  ActionResult Index()
        {

            List<Forum> forums = new List<Forum>();
            forums = this.GetForums();
            ViewBag.forums = forums;
            return View(forums);

        }
        /*
        static async Task GetForumsAsync(List<Forum> list)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://forumyoup.apphb.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/blog");

                if (response.IsSuccessStatusCode)
                {
                    list = await response.Content.ReadAsAsync<List<Forum>>();
                }
            }
        }*/

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
