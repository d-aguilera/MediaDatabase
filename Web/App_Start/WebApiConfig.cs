using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MediaDatabase.Web.Config
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            if (null == config)
                throw new ArgumentNullException("config");

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
