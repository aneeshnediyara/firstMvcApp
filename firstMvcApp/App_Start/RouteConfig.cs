using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;

namespace firstMvcApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "CartRoute", 
                //url: "Shop/List", 
                url: "Shop/{controller}/do{action}/{pageNo}",               
                defaults: new { Controller = "Cart", action = "Index" }               
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}/{*catchall}",
                //home/index/abc/page/1/2/100
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                //, constraints: new { Controller = "^H.*", id = new RangeRouteConstraint(0, 100) }
            );
        }
    }
}
