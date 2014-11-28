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
using YOUP_Design.Models.Profile;
namespace YOUP_Design.Controllers
{
    /// <summary>
    /// Classe de controller de la partie Forum.
    /// </summary>
    public class ForumController : Controller
    {
        // METHODE EXECUTION DES REQUETES SUR API
        #region ExecuteRequest
        /// <summary>
        ///  Requete sur API Forum
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
        /// <summary>
        ///  Requete sur API Profil
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public T ExecuteProfil<T>(RestRequest request) where T : new()
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

            Categorie forum = new Categorie();
            forum = this.GetForum(id);
            List<Topic> topics = new List<Topic>();
            topics = this.GetTopicsByCategId(id);
            List<YOUP_Design.Classes.Profile.Utilisateur> users = new List<Classes.Profile.Utilisateur>();
            users = getUsers();
            ViewBag.forum = forum;
            ViewBag.users = users;
            ViewBag.topics = topics;
            return View(topics);

        }

        public Categorie GetForum(int id)
        {
            var request = new RestRequest("api/Category/" + id, Method.GET);
            var result = Execute<Categorie>(request);

            return result;

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

        /// <summary>
        /// Envois vers la vue de création d'un topic.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult NewTopic(int id)
        {


            return View(id);

        }


        /// <summary>
        /// Méthode de récupération du post.
        /// Le POST ne fonctionne que si l'utilisateur est connecté ! 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="editor1"></param>
        /// <param name="TitreTopic"></param>
        /// <param name="idCateg"></param>
        /// <returns></returns>
        [HttpPost, ValidateInput(false)]
        public ActionResult NewTopic(Topic t, string editor1, string TitreTopic, int idCateg)
        {

            Topic topic = new Topic();
            topic.Nom = TitreTopic;
            topic.DescriptifTopic = editor1;
            topic.Sujet_id = idCateg;
            setTopic(topic);

            return Topics(idCateg);

        }
        /// <summary>
        /// Ajout du topic créé.
        /// Ne fonctionne que si l'utilisateur est connecté (cookies)
        /// </summary>
        /// <param name="topic"></param>
        public void setTopic(Topic topic)
        {
            var request = new RestRequest("api/Topic/", Method.POST);
            var u = ProfileCookie.GetCookie(HttpContext);
            if (u != null)
            {
                request.AddParameter("Sujet_id", topic.Sujet_id);
                request.AddParameter("Nom", topic.Nom);
                request.AddParameter("Resolu", 0);
                request.AddParameter("Utilisateur_id", u.Utilisateur_Id);
                request.AddParameter("DateCreation", DateTime.Now.ToString(new CultureInfo("en-us")));
                request.AddParameter("DescriptifTopic", "" + topic.DescriptifTopic);
                Execute<Topic>(request);

            }
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
            Topic t = new Topic();
            t = this.getTopic(id);
            List<Message> messages = new List<Message>();
            messages = this.getMessagesByTopicId(id);
            List<YOUP_Design.Classes.Profile.Utilisateur> users = new List<Classes.Profile.Utilisateur>();
            users = getUsers();
            ViewBag.topic = t;
            ViewBag.users = users;
            ViewBag.messages = messages;
            return View();
        }

        public Topic getTopic(int id)
        {
            var request = new RestRequest("api/Topic/" + id, Method.GET);
            var result = Execute<Topic>(request);

            return result;

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
        /// <summary>
        /// Récupère la liste des utilisateurs.
        /// </summary>
        /// <returns></returns>
        public List<YOUP_Design.Classes.Profile.Utilisateur> getUsers()
        {
            var request = new RestRequest("api/UserSmall/", Method.GET);
            var result = ExecuteProfil<List<YOUP_Design.Classes.Profile.Utilisateur>>(request);

            return result;

        }

        /// <summary>
        /// Méthode de récupération du post.
        /// Le POST ne fonctionne que si l'utilisateur est connecté ! 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="editor1"></param>
        /// <param name="idTopic"></param>
        /// <returns></returns>
        [HttpPost, ValidateInput(false)]
        public ActionResult Discussion(MessageModel m, string editor1, int idTopic)
        {

            Message message = new Message();
            message.ContenuMessage = editor1;
            message.Topic_id = idTopic;
            setMessage(message);


            //messages = this.getMessagesByTopicId(id);
            return Discussion(idTopic);



        }
        /// <summary>
        /// Ajout du message créé.
        /// Ne fonctionne que si l'utilisateur est connecté (cookies)
        /// </summary>
        /// <param name="message"></param>
        public void setMessage(Message message)
        {
            var request = new RestRequest("api/Message/", Method.POST);
            var u = ProfileCookie.GetCookie(HttpContext);
            if (u != null)
            {
                request.AddParameter("Topic_id", message.Topic_id);
                request.AddParameter("Utilisateur_id", u.Utilisateur_Id);
                request.AddParameter("DatePoste", DateTime.Now.ToString(new CultureInfo("en-us")));
                request.AddParameter("ContenuMessage", "" + message.ContenuMessage);
                Execute<Message>(request);
            }

        }
        #endregion
    }
}
