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
using System.Globalization;
namespace YOUP_Design.Controllers
{
    public class ForumController : Controller
    {
        // METHODE EXECUTION DES REQUETES SUR API
        #region ExecuteRequest
        /// <summary>
        /// Requete sur API
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient("http://forumyoup.apphb.com/");
            var response = client.Execute<T>(request);
            return response.Data;
        }

        public T ExecuteUser<T>(RestRequest request) where T : new()
        {
            var client = new RestClient("http://aspmoduleprofil.azurewebsites.net/");
            var response = client.Execute<T>(request);
            return response.Data;
        }

        #endregion

        // METHODES SUR LA VUE FORUM
        #region Forums

        /// <summary>
        /// Retourne la vue Index qui représente la liste des forums.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            List<Forum> forums = new List<Forum>();
            forums = this.GetForums();

            List<Categorie> categs = new List<Categorie>();
            categs = this.GetCategories();

            ViewBag.forums = forums;
            ViewBag.categs = categs;
            return View(forums);

        }

        /// <summary>
        /// GetForums permet de récupérer la liste complète des forums.
        /// </summary>
        /// <returns></returns>
        public List<Forum> GetForums()
        {
            var request = new RestRequest("api/Forums", Method.GET);
            var result = Execute<List<Forum>>(request);

            return result;

        }

        /// <summary>
        /// Récupère la liste complète des catégories de forum.
        /// </summary>
        /// <returns></returns>
        public List<Categorie> GetCategories()
        {
            var request = new RestRequest("api/Category/", Method.GET);
            var result = Execute<List<Categorie>>(request);

            return result;

        }

        #endregion

        // METHODES SUR LA VUE TOPIC
        #region Topic
        /// <summary>
        /// Retourne la vue Topics qui représente la liste des topics du forum séléctionné.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Topics(int id)
        {

            List<Topic> topics = new List<Topic>();
            topics = this.GetTopicsByCategId(id);

            ViewBag.topics = topics;
            return View(topics);

        }
        /// <summary>
        /// 
        /// </summary>Récupère la liste des topics de la catégorie séléctionnée.
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Topic> GetTopicsByCategId(int id)
        {
            var request = new RestRequest("api/TopicCategory/" + id, Method.GET);
            var result = Execute<List<Topic>>(request);

            return result;

        }
        #endregion

        // METHODES SUR LA VUE DISCUSSION
        #region Discussion
        /// <summary>
        /// Retourne la vue Discussion qui représente la liste des messages sur un topic.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Discussion(int id)
        {
            List<Message> messages = new List<Message>();
            messages = this.getMessagesByTopicId(id);
            List<YOUP_Design.Classes.Profile.Utilisateur> users = new List<Classes.Profile.Utilisateur>();
            users = this.getUsers();

            ViewBag.users = users;
            ViewBag.messages = messages;
            return View();
        }
        /// <summary>
        /// Récupère la liste des messages du topic séléctionné.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Message> getMessagesByTopicId(int id)
        {
            var request = new RestRequest("api/MessageTopic/" + id, Method.GET);
            var result = Execute<List<Message>>(request);

            return result;

        }
        public List<YOUP_Design.Classes.Profile.Utilisateur> getUsers()
        {
            var request = new RestRequest("api/UserSmall/", Method.GET);
            var result = ExecuteUser<List<YOUP_Design.Classes.Profile.Utilisateur>>(request);

            return result;

        }

   


        [HttpPost, ValidateInput(false)]
        public ActionResult Discussion(MessageModel m, string editor1, string idTopic)
        {
     
                Message message = new Message();
                message.ContenuMessage = editor1;
                message.Topic_id = int.Parse(idTopic);
                setMessage(message);

                //messages = this.getMessagesByTopicId(id);
                return RedirectToAction("Index", "Forum");
 
        }

        public void setMessage(Message message)
        {
            var request = new RestRequest("api/Message/", Method.POST);

            request.AddParameter("Topic_id",message.Topic_id);
            request.AddParameter("Utilisateur_id",7);
            request.AddParameter("DatePoste", DateTime.Now.ToString(new CultureInfo("en-us")));
            request.AddParameter("ContenuMessage",""+message.ContenuMessage);
            Execute<Message>(request);


        }
        #endregion




        // METHODES NON UTILISEES
        #region Unused

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

        #endregion
    }
}
