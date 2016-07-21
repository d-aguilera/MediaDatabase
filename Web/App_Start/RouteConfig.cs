using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MediaDatabase.Web.Config
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            if (null == routes)
                throw new ArgumentNullException("routes");

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Scan", id = UrlParameter.Optional }
            );
        }
    }
}
