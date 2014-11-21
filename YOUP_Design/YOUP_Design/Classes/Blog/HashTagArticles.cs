using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Design.Classes.Blog
{
    public class HashTagArticles
    {
        public int HastTagArticle_id { get; set; }

        public int Article_id { get; set; }

        public string Mots { get; set; }

        public HashTagArticles()
        {

        }
    }
}