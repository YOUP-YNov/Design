using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace YOUP_Design.Models.Profile
{
    public static class ProfileConstantes
    {
        public static readonly string UrlAPIProfile = ConfigurationManager.AppSettings["ApiProfil"];
        public static readonly string CookieNameProfile = "ASPCookieUtilisateur";
    }
}