using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Products
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "ProductDetails",
               url: "ProductDetails/{id}",
               defaults: new { controller = "Home", action = "ProductDetails", id = UrlParameter.Optional }
           );

            routes.MapRoute(
             name: "ProductDetailsEdit",
             url: "ProductDetailsEdit/{id}",
             defaults: new { controller = "Home", action = "ProductDetailsEdit", id = UrlParameter.Optional }
         );

            routes.MapRoute(
           name: "ProductDetailsUpdate",
           url: "ProductDetailsUpdate/{id}",
           defaults: new { controller = "Home", action = "ProductDetailsUpdate", id = UrlParameter.Optional }
       );


            routes.MapRoute(
         name: "Index",
         url: "Index/{id}",
         defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
     );


  


            routes.MapRoute(
            name: "Details",
            url: "Details/{id}",
          defaults: new { controller = "Home", action = "Details", id = UrlParameter.Optional }
         );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Details", id = UrlParameter.Optional }
            );
        }
    }
}
