using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity1_3.Controllers
{
    public class CustomAuthorizationAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //if user is not authenticated, they will be redirected to the login page
            filterContext.Result = new RedirectResult("/Login");
        }
    }
}