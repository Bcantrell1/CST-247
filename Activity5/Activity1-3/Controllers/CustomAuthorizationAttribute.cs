using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity1_3.Controllers
{
    public class CustomAuthorizationAttribute : FilterAttribute, IAuthorizationFilter 
    {
        void IAuthorizationFilter.OnAuthorization(AuthorizationContext filterContext)
        {

            if (System.Web.HttpContext.Current.Session["user"] == null)
                filterContext.Result = new RedirectResult("/Login/Index");
        }
    }
}