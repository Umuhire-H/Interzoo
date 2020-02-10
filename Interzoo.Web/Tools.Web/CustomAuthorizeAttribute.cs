using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Interzoo.Web.Tools.Web
{
    [AttributeUsageAttribute(AttributeTargets.Class| AttributeTargets.Method, Inherited =true, AllowMultiple = true)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!SessionUtilisateur.IsConnected)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index", area = "" }));
            }
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return SessionUtilisateur.IsConnected;
        }

    }
}