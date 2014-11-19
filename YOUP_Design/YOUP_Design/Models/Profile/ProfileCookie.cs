using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using YOUP_Design.Classes.Profile;

namespace YOUP_Design.Models.Profile
{
    public static class ProfileCookie
    {
        public static void RemoveCookie(HttpContextBase HttpContext)
        {
            HttpCookie myCookie = new HttpCookie(ProfileConstantes.CookieNameProfile);
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            HttpContext.Response.Cookies.Add(myCookie);
        }

        public static void CreateCookie(HttpContextBase HttpContext, Utilisateur utilisateur)
        {
            HttpCookie cookie = new HttpCookie(ProfileConstantes.CookieNameProfile);
            cookie.Value = Convert.ToBase64String(Encoding.UTF8.GetBytes(utilisateur.GetJson()));
            cookie.HttpOnly = true;
            HttpContext.Response.Cookies.Add(cookie);
        }

        public static Utilisateur GetCookie(HttpContextBase HttpContext)
        {
            if (HttpContext.Request.Cookies.Get(ProfileConstantes.CookieNameProfile) != null && !string.IsNullOrEmpty(HttpContext.Request.Cookies.Get(ProfileConstantes.CookieNameProfile).Value))
            {
                try
                {
                    var cookie = HttpContext.Request.Cookies.Get(ProfileConstantes.CookieNameProfile).Value;
                    var json = Encoding.UTF8.GetString(Convert.FromBase64String(cookie));
                    var u = new JavaScriptSerializer().Deserialize<Utilisateur>(json);
                    if (u != null)
                        return (Utilisateur)u;
                }
                catch (Exception E)
                {
                    return null;
                }

            }
            return null;
        }
    }
}