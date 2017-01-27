using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StadisticJCE
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Citizen",
                url: "{controller}/{action}/{pageNumber}/{pageSize}",
                defaults: new { controller = "Citizen", action = "fetchCitizens",
                    pageNumber = UrlParameter.Optional,
                    pageSize = UrlParameter.Optional
                }
            );

            routes.MapRoute(              
                name: "Profession",               
                url: "{controller}/{action}",              
                defaults: new { controller = "Profession", action = "getAllProfession" }         
                );

            routes.MapRoute(            
                name: "Province",            
                url: "{controller}/{action}",            
                defaults: new { controller = "Province", action = "getAllProvinces" }
             );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
