using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BibleVerseApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Search",
               url: "{Search}",
               defaults: new { controller = "Search", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Insert",
                url: "{Insert}",
                defaults: new { controller = "Insert", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
