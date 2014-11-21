using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YOUP_Design.Models.Profile
{
    public sealed class YoupAuthorize : ActionFilterAttribute
    {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var u = ProfileCookie.GetCookie(filterContext.HttpContext);
                if (u == null)
                    filterContext.Result = new RedirectResult("~/Profile/Login");
            }
    }
}