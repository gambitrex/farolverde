﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FarolVerde
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ProcessUser",
                url: "ProcessUser/{id}",
                defaults: new { controller = "Home", action = "ProcessUser", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "GetRoute",
                url: "GetRoute/{id}",
                defaults: new { controller = "Home", action = "GetRoute", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
