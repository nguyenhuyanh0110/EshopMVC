﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EshopMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ProductCategory",
                url: "san-pham/{Metatitle}-{id}",
                defaults: new { controller = "ProductCategory", action = "ListProduct", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ProductDetail",
                url: "chi-tiet/{Metatitle}-{id}",
                defaults: new { controller = "ProductCategory", action = "ProductDetail", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Add Product",
                url: "them-san-pham",
                defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Order",
                url: "order",
                defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
