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
using YOUP_Design.Classes.Profile;
using YOUP_Design.Models.Blog;
using YOUP_Design.Models.Profile;

namespace YOUP_Design.Controllers

{
    public class BlogController : Controller
    {

        const string blogApiUrl = "http://youp-blog.azurewebsites.net/";
        const string eventApiUrl = "http://youp-evenementapi.azurewebsites.net/";
        const string profileApiUrl = "http://aspmoduleprofil.azurewebsites.net/";

        public T Execute<T>(RestRequest request, string url) where T : new()
        {
            var client = new RestClient(url);
            var response = client.Execute<T>(request);
            return response.Data;
        }

        //public T ExecuteEvent<T>(RestRequest request) where T : new()
        //{
        //    var client = new RestClient("http://youp-evenementapi.azurewebsites.net/");
        //    var response = client.Execute<T>(request);
        //    return response.Data;
        //}

        public List<Blog> GetBlogs()
        {
            var request = new RestRequest("api/blog", Method.GET);
            var result = Execute<List<Blog>>(request, blogApiUrl);
            return result;
        }

        public UtilisateurSmall GetUserSmall(int id)
        {
            var request = new RestRequest("api/UserSmall/{id}", Method.GET);
            request.AddParameter("id", id, ParameterType.UrlSegment);
            var result = Execute<UtilisateurSmall>(request, profileApiUrl);
            return result;
        }

        public Classes.Blog.Categorie GetBlogCategorie(int id)
        {
            var request = new RestRequest("api/category/{id}", Method.GET);
            request.AddParameter("id", id, ParameterType.UrlSegment);
            var result = Execute<Classes.Blog.Categorie>(request, blogApiUrl);
            return result;
        }

        public List<Commentaire> GetArticleComments(int articleId)
        {
            var request = new RestRequest("api/article/comment/{articleId}", Method.GET);
            request.AddParameter("articleId", articleId, ParameterType.UrlSegment);
            var result = Execute<List<Commentaire>>(request, blogApiUrl);
            return result;
        }

        public ActionResult Blog_commentaire(int ArticleId)
        {
            List<Commentaire> comments = GetArticleComments(ArticleId);
            List<UtilisateurSmall> users = new List<UtilisateurSmall>();
            foreach (Commentaire c in comments)
            {
                users.Add(GetUserSmall(c.Utilisateur_id));
            }
            ViewData["ArticleComments"] = comments as List<Commentaire>;
            ViewData["ArticleCommentsOwner"] = users as List<UtilisateurSmall>;
            ViewBag.articleId = ArticleId;
            return View();
        }

        public ActionResult Index()
        {
            var u = ProfileCookie.GetCookie(HttpContext);
            if (u != null)
            {
                Blog blog = GetBlogUser(u.Utilisateur_Id);
                if (blog == null)
                    ViewData["hasBlog"] = false;
                else
                    ViewData["hasBlog"] = true;

                List<Blog> blogs = new List<Blog>();
                blogs = this.GetBlogs();

                List<UtilisateurSmall> users = new List<UtilisateurSmall>();
                List<YOUP_Design.Classes.Blog.Categorie> blogsCategory = new List<YOUP_Design.Classes.Blog.Categorie>();
                foreach (Blog b in blogs)
                {
                    users.Add(GetUserSmall(b.Utilisateur_id));
                    blogsCategory.Add(GetBlogCategorie(b.Categorie_id));
                }

                ViewData["BlogSmall"] = blogs as List<Blog>;
                ViewData["BlogSmallUser"] = users as List<UtilisateurSmall>;
                ViewData["BlogCategories"] = blogsCategory as List<YOUP_Design.Classes.Blog.Categorie>;
                return View();
            }

            return RedirectToAction("Login", "Profile");

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
            var u = ProfileCookie.GetCookie(HttpContext);

                var request = new RestRequest("api/Category", Method.GET);
                var result = Execute<List<YOUP_Design.Classes.Blog.Categorie>>(request, blogApiUrl);
                ViewData["Category"] = result as IEnumerable<YOUP_Design.Classes.Blog.Categorie>;
                var requestCat = new RestRequest("api/Theme", Method.GET);
                var resultCat = Execute<List<Theme>>(requestCat, blogApiUrl);
                
                IEnumerable<Theme> themeImages = (resultCat as IEnumerable<Theme>).Where(x => !string.IsNullOrEmpty(x.ImageChemin));
                IEnumerable<Theme> themeCouleurs = (resultCat as IEnumerable<Theme>).Where(x => !string.IsNullOrEmpty(x.Couleur));

                IEnumerable<Theme> themes = themeCouleurs.Concat(themeImages);
                ViewData["Theme"] = themes as IEnumerable<Theme>;
            
            return View();

            #region comment
            //var request = new RestRequest("api/Category", Method.GET);
            //var result = Execute<List<Categorie>>(request);
            //ViewData["Category"] = result as IEnumerable<Categorie>;

            //var requestCat = new RestRequest("api/Theme", Method.GET);
            //var resultCat = Execute<List<Theme>>(requestCat);


            //IEnumerable<Theme> themeImages = (resultCat as IEnumerable<Theme>).Where(x=> !string.IsNullOrEmpty(x.ImageChemin));
            //IEnumerable<Theme> themeCouleurs = (resultCat as IEnumerable<Theme>).Where(x => !string.IsNullOrEmpty(x.Couleur));

            //IEnumerable<Theme> themes = themeCouleurs.Concat(themeImages);
            //ViewData["Theme"] = themes as IEnumerable<Theme>;
            #endregion
        }


        public ActionResult Blog_trueedit()
        {
            var u = ProfileCookie.GetCookie(HttpContext);

            
                var request = new RestRequest("api/Category", Method.GET);
                var result = Execute<List<YOUP_Design.Classes.Blog.Categorie>>(request, blogApiUrl);
                ViewData["Category"] = result as IEnumerable<YOUP_Design.Classes.Blog.Categorie>;

                var requestCat = new RestRequest("api/Theme", Method.GET);
                var resultCat = Execute<List<Theme>>(requestCat, blogApiUrl);

                IEnumerable<Theme> themeImages = (resultCat as IEnumerable<Theme>).Where(x => !string.IsNullOrEmpty(x.ImageChemin));
                IEnumerable<Theme> themeCouleurs = (resultCat as IEnumerable<Theme>).Where(x => !string.IsNullOrEmpty(x.Couleur));

                IEnumerable<Theme> themes = themeCouleurs.Concat(themeImages);
                ViewData["Theme"] = themes as IEnumerable<Theme>;

                Blog userBlog = GetBlogUser(u.Utilisateur_Id);
                ViewData["UserBlog"] = userBlog as Blog;
            
            return View();

            #region comment
            //var request = new RestRequest("api/Category", Method.GET);
            //var result = Execute<List<Categorie>>(request);
            //ViewData["Category"] = result as IEnumerable<Categorie>;

            //var requestCat = new RestRequest("api/Theme", Method.GET);
            //var resultCat = Execute<List<Theme>>(requestCat);


            //IEnumerable<Theme> themeImages = (resultCat as IEnumerable<Theme>).Where(x=> !string.IsNullOrEmpty(x.ImageChemin));
            //IEnumerable<Theme> themeCouleurs = (resultCat as IEnumerable<Theme>).Where(x => !string.IsNullOrEmpty(x.Couleur));

            //IEnumerable<Theme> themes = themeCouleurs.Concat(themeImages);
            //ViewData["Theme"] = themes as IEnumerable<Theme>;
            #endregion
        }

        public ActionResult Blog_vue(int UserId, int BlogId)
        {
            List<Article> articles = new List<Article>();
            articles = this.GetBlog(UserId, BlogId);
            ViewBag.articles = articles;

            UtilisateurSmall user = GetUserSmall(UserId);
            ViewData["UserBlogVue"] = user as UtilisateurSmall; 


            foreach (var a in articles)
            {
                a.NbComments = GetArticleComments(a.Article_id).Where(x=>x.Article_id>0).Count();
            }

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

            var result = Execute<Blog>(request, blogApiUrl);
            return result;
        }

        //public ActionResult Blog_vue(int UserId, int BlogId)
        //{
        //    List<Article> blog = new List<Article>();
        //    blog = this.GetBlog(UserId, BlogId);
        //    ViewBag.articles = blog;
        //    return View(blog);
        //}

        public List<Article> GetBlog(int UserId, int BlogId)
        {
            //var request = new RestRequest("api/article?utilisateurId="+UserId+"&blogId="+BlogId, Method.GET);
            var request = new RestRequest("api/article?utilisateurId=" + UserId + "&blogId=" + BlogId, Method.GET);

            //request.AddParameter("utilisateurId", UserId, ParameterType.UrlSegment);
            //request.AddParameter("blogId", BlogId, ParameterType.UrlSegment);

            var result = Execute<List<Article>>(request, blogApiUrl);
            return result;
        }

        public ActionResult Blog_liste_article()
        {
            var u = ProfileCookie.GetCookie(HttpContext);
            if (u != null)
            {
                int userBlogId = GetBlogUser(u.Utilisateur_Id).Blog_id;

                List<Article> userBlogArticles = GetBlog(u.Utilisateur_Id, userBlogId);
                return View(userBlogArticles);
            }

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

                var u = ProfileCookie.GetCookie(HttpContext);
                Blog blog = new Blog() { Utilisateur_id = u.Utilisateur_Id, TitreBlog = model.TitreBlog, Categorie_id = model.CategorieId, Theme_id = model.ThemeId};

                //Blog blog = new Blog() { Utilisateur_id = 124, TitreBlog = model.TitreBlog, Categorie_id = model.CategorieId, Theme_id = model.ThemeId};
                //httpclient (voir msdn)
                
                
                var request = new RestRequest("api/blog", Method.POST);
                request.AddObject(blog);
                //request.AddParameter("blog", blog, ParameterType.GetOrPost);
                
                
                var result = Execute<Blog>(request, blogApiUrl);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // POST: /Blog/Update
        [HttpPost]
        public ActionResult UpdateBlog(BlogModel model)
        {
            try
            {
                //Blog blog = new Blog() { TitreBlog = model.TitreBlog, Actif = true, Categorie_id = model.CategorieId, Promotion = false, DateCreation = DateTime.Now, Theme_id = model.ThemeId};

                var u = ProfileCookie.GetCookie(HttpContext);
                Blog blog = new Blog() { Utilisateur_id = u.Utilisateur_Id, TitreBlog = model.TitreBlog, Categorie_id = model.CategorieId, Theme_id = model.ThemeId, Actif = true };

                //Blog blog = new Blog() { Utilisateur_id = 124, TitreBlog = model.TitreBlog, Categorie_id = model.CategorieId, Theme_id = model.ThemeId};
                //httpclient (voir msdn)


                var request = new RestRequest("api/blog/{id}", Method.PUT);
                request.AddObject(blog);
                request.AddParameter("id", GetBlogUser(u.Utilisateur_Id).Blog_id, ParameterType.UrlSegment);
                //request.AddParameter("blog", blog, ParameterType.GetOrPost);


                var result = Execute<Blog>(request, blogApiUrl);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Blog_article_edit()
        {
            var u = ProfileCookie.GetCookie(HttpContext);
            var request = new RestRequest("api/Profil/{id}/Evenements", Method.GET);
            request.AddParameter("id", u.Utilisateur_Id, ParameterType.UrlSegment);
            var result = Execute<List<EvenementFront>>(request, eventApiUrl);
            ViewData["Evenements"] = result as IEnumerable<EvenementFront>;

            return View();
        }

        public ActionResult Blog_article_trueedit(int articleId)
        {
            var u = ProfileCookie.GetCookie(HttpContext);
            var request = new RestRequest("api/Profil/{id}/Evenements", Method.GET);
            request.AddParameter("id", u.Utilisateur_Id, ParameterType.UrlSegment);
            var result = Execute<List<EvenementFront>>(request, eventApiUrl);
            ViewData["Evenements"] = result as IEnumerable<EvenementFront>;

            Article article = GetBlog(u.Utilisateur_Id, GetBlogUser(u.Utilisateur_Id).Blog_id).Where(x => x.Article_id == articleId).FirstOrDefault();
            ViewData["selectedArticle"] = article as Article;

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
                var u = ProfileCookie.GetCookie(HttpContext);

                List<HashTagArticles> tagList = new List<HashTagArticles>();
                if(!string.IsNullOrEmpty(model.Tags))
                {
                    string[] tags;
                    tags = model.Tags.Split(';');
                    for (int i = 0; i < tags.Length; i++)
                    {
                        tagList.Add(new HashTagArticles { Mots = tags[i] });
                    }
                }
                
                

                Article article = new Article() { Blog_id = GetBlogUser(u.Utilisateur_Id).Blog_id, ListTags=tagList, TitreArticle = model.TitreArticle, ImageChemin = Session["images"] as string, ContenuArticle = model.ContenuArticle, Evenement_id = (model.EventId != -1 ? (int?)model.EventId : null) };
                //httpclient (voir msdn)


                var request = new RestRequest("api/article", Method.POST);
                request.AddObject(article);
                //request.AddParameter("blog", blog, ParameterType.GetOrPost);


                var result = Execute<Article>(request, blogApiUrl);

                return RedirectToAction("Blog_vue", new { UserId = u.Utilisateur_Id, BlogId = GetBlogUser(u.Utilisateur_Id).Blog_id });
            }
            catch
            {
                return View();
            }
        }

        // POST: /Blog/CreateArticle
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateArticle(ArticleModel model)
        {
            try
            {
                //Blog blog = new Blog() { TitreBlog = model.TitreBlog, Actif = true, Categorie_id = model.CategorieId, Promotion = false, DateCreation = DateTime.Now, Theme_id = model.ThemeId};
                var u = ProfileCookie.GetCookie(HttpContext);

                List<HashTagArticles> tagList = new List<HashTagArticles>();
                if (!string.IsNullOrEmpty(model.Tags))
                {
                    string[] tags;
                    tags = model.Tags.Split(';');
                    for (int i = 0; i < tags.Length; i++)
                    {
                        tagList.Add(new HashTagArticles { Mots = tags[i] });
                    }
                }



                Article article = new Article() { Article_id = model.Id, Blog_id = GetBlogUser(u.Utilisateur_Id).Blog_id, ListTags = tagList, TitreArticle = model.TitreArticle, ImageChemin = model.ImageChemin, ContenuArticle = model.ContenuArticle, Evenement_id = (model.EventId != -1 ? (int?)model.EventId : null) };
                //httpclient (voir msdn)


                var request = new RestRequest("api/article/{id}", Method.PUT);
                request.AddObject(article);
                request.AddParameter("id",model.Id, ParameterType.UrlSegment);
                //request.AddParameter("blog", blog, ParameterType.GetOrPost);


                var result = Execute<Article>(request, blogApiUrl);

                return RedirectToAction("Blog_vue", new { UserId = u.Utilisateur_Id, BlogId = GetBlogUser(u.Utilisateur_Id).Blog_id });
            }
            catch
            {
                return View();
            }
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CreateCommentaire(CommentaireModel model)
        {
            try
            {
                //Blog blog = new Blog() { TitreBlog = model.TitreBlog, Actif = true, Categorie_id = model.CategorieId, Promotion = false, DateCreation = DateTime.Now, Theme_id = model.ThemeId};
                var u = ProfileCookie.GetCookie(HttpContext);



                Commentaire comment = new Commentaire() {Actif=true, Article_id=model.ArticleId, ContenuCommentaire = model.ContenuCommentaire, Utilisateur_id =u.Utilisateur_Id};
                //httpclient (voir msdn)


                var request = new RestRequest("api/comment", Method.POST);
                request.AddObject(comment);
                //request.AddParameter("blog", blog, ParameterType.GetOrPost);


                var result = Execute<Commentaire>(request, blogApiUrl);

                return RedirectToAction("Blog_commentaire", new { ArticleId = model.ArticleId });
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
