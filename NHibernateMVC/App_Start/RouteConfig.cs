﻿using System.Web.Mvc;
using System.Web.Routing;

namespace NHibernateMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Employee", action = "Index", id = UrlParameter.Optional });
        }
    }
}