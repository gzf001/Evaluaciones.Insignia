﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Castellano.Web.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Login", id = UrlParameter.Optional }
            );

            #region Utilidades

            routes.MapRoute(
                name: "Utils",
                url: "{controller}/{action}",
                defaults: new { controller = "Utils", action = "GenerateId" }
            );

            #endregion
        }
    }
}