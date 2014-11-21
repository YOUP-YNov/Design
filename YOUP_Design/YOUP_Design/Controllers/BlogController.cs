using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YOUP_Design.Classes.Blog;
using YOUP_Design.Classes.Evenement;
using YOUP_Design.Models.Blog;

namespace YOUP_Design.Controllers

{
    public class BlogController : Controller
    {

        public T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient("http://youp-blog.azurewebsites.net/");
            var response = client.Execute<T>(request);
            return response.Data;
        }

        public T ExecuteEvent<T>(RestRequest request) where T : new()
        {
            var client = new RestClient("http://youp-evenementapi.azurewebsites.net/");
            var response = client.Execute<T>(request);
            return response.Data;
        }

        public List<Blog> GetBlogs()
        {
            var request = new RestRequest("api/blog", Method.GET);
            var result = Execute<List<Blog>>(request);
            return result;
        }
        public ActionResult Index()
        {
            List<Blog> blogs = new List<Blog>();
            blogs = this.GetBlogs();
            ViewBag.blogs = blogs;
            return View(blogs);
        }

        public ActionResult ModComment()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult PubBlog()
        {
            return View();
        }

        public ActionResult Blog_edit()
        {
            var request = new RestRequest("api/Category", Method.GET);
            var result = Execute<List<Categorie>>(request);
            ViewData["Category"] = result as IEnumerable<Categorie>;

            var requestCat = new RestRequest("api/Theme", Method.GET);
            var resultCat = Execute<List<Theme>>(requestCat);


            IEnumerable<Theme> themeImages = (resultCat as IEnumerable<Theme>).Where(x=> !string.IsNullOrEmpty(x.ImageChemin));
            IEnumerable<Theme> themeCouleurs = (resultCat as IEnumerable<Theme>).Where(x => !string.IsNullOrEmpty(x.Couleur));

            IEnumerable<Theme> themes = themeCouleurs.Concat(themeImages);
            ViewData["Theme"] = themes as IEnumerable<Theme>;

            return View();
        }


        public ActionResult Blog_vue(int UserId, int BlogId)
        {
            List<Article> articles = new List<Article>();
            articles = this.GetBlog(UserId, BlogId);
            ViewBag.articles = articles;

            Blog blogs = new Blog();
            blogs = this.GetBlogUser(UserId);
            ViewData["Blog"] = blogs as Blog;

            return View(articles);
        }
        public Blog GetBlogUser(int UserId)
        {
            //var request = new RestRequest("api/article?utilisateurId="+UserId+"&blogId="+BlogId, Method.GET);
            var request = new RestRequest("api/blog?userId=" + UserId, Method.GET);

            //request.AddParameter("utilisateurId", UserId, ParameterType.UrlSegment);
            //request.AddParameter("blogId", BlogId, ParameterType.UrlSegment);

            var result = Execute<Blog>(request);
            return result;
        }

        public List<Article> GetBlog(int UserId, int BlogId)
        {
            //var request = new RestRequest("api/article?utilisateurId="+UserId+"&blogId="+BlogId, Method.GET);
            var request = new RestRequest("api/article?utilisateurId=" + UserId + "&blogId=" + BlogId, Method.GET);

            //request.AddParameter("utilisateurId", UserId, ParameterType.UrlSegment);
            //request.AddParameter("blogId", BlogId, ParameterType.UrlSegment);

            var result = Execute<List<Article>>(request);
            return result;
        }

        public ActionResult Blog_liste_article()
        {
            return View();
        }

        public ActionResult Blog_voir_plus()
        {
            return View();
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
                //Blog blog = new Blog() { TitreBlog = model.TitreBlog, Actif = true, Categorie_id = model.CategorieId, Promotion = false, DateCreation = DateTime.Now, Theme_id = model.ThemeId};

                Blog blog = new Blog() { Utilisateur_id = 124, TitreBlog = model.TitreBlog, Categorie_id = model.CategorieId, Theme_id = model.ThemeId};
                //httpclient (voir msdn)
                
                
                var request = new RestRequest("api/blog", Method.POST);
                request.AddObject(blog);
                //request.AddParameter("blog", blog, ParameterType.GetOrPost);
                
                
                var result = Execute<Blog>(request);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Blog_article_edit()
        {
            var request = new RestRequest("api/Profil/99/Evenements", Method.GET);
            var result = ExecuteEvent<List<EvenementFront>>(request);
            ViewData["Evenements"] = result as IEnumerable<EvenementFront>;


            return View();
        }

        //
        // POST: /Blog/CreateArticle
        [HttpPost, ValidateInput(false)]
        public ActionResult CreateArticle(ArticleModel model)
        {
            try
            {
                //Blog blog = new Blog() { TitreBlog = model.TitreBlog, Actif = true, Categorie_id = model.CategorieId, Promotion = false, DateCreation = DateTime.Now, Theme_id = model.ThemeId};

                Article article = new Article() { Blog_id = 128, TitreArticle = model.TitreArticle, ImageChemin = Session["images"] as string, ContenuArticle = model.ContenuArticle, Evenement_id = (model.EventId != -1 ? (int?)model.EventId : null) };
                //httpclient (voir msdn)


                var request = new RestRequest("api/article", Method.POST);
                request.AddObject(article);
                //request.AddParameter("blog", blog, ParameterType.GetOrPost);


                var result = Execute<Article>(request);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public string UploadPicture()
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0 &&
                    (file.ContentType.Contains("jpg") || file.ContentType.Contains("png") || file.ContentType.Contains("jpeg")))
                {
                    string guid = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/UploadsPic/"), guid);
                    file.SaveAs(path);
                    var pictUrl = "http://" + Request.Url.Authority + "/UploadsPic/" + guid;
                   
                    Session["images"] = pictUrl;
                    return pictUrl;
                }
            }
            return "fail";
        }

        //[HttpPost, ValidateInput(false)]
        //public ActionResult Discussion(MessageModel m, string editor1)
        //{

        //    Message message = new Message();
        //    message.ContenuMessage = editor1;
        //    setMessage(message);

        //    //messages = this.getMessagesByTopicId(id);
        //    return RedirectToAction("Index", "Forum");

        //}

        //public void setMessage(Message message)
        //{
        //    var request = new RestRequest("api/Message/", Method.POST);

        //    request.AddParameter("Message_id", 10000);
        //    request.AddParameter("Topic_id", 20);
        //    request.AddParameter("Utilisateur_id", 7);
        //    request.AddParameter("DatePoste", DateTime.Now.ToString(new CultureInfo("en-us")));
        //    request.AddParameter("ContenuMessage", "" + message.ContenuMessage);
        //    Execute<Message>(request);


        //}





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
