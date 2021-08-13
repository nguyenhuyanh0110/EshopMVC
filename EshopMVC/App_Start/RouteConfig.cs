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

            //ignore root captcha
            routes.IgnoreRoute("{*botdetect}",
   new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
                name: "ProductCategory",
                url: "san-pham/{Metatitle}-{id}",
                defaults: new { controller = "ProductClient", action = "ListProduct", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ProductDetail",
                url: "chi-tiet/{Metatitle}-{id}",
                defaults: new { controller = "ProductClient", action = "ProductDetail", id = UrlParameter.Optional }
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
                name: "CheckOut",
                url: "thanh-toan",
                defaults: new { controller = "Cart", action = "Checkout", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Invoice",
                url: "hoa-don",
                defaults: new { controller = "Cart", action = "Invoice", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "404",
                url: "error",
                defaults: new { controller = "NotFound", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Contact",
                url: "lien-he",
                defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Register",
                url: "dang-ky",
                defaults: new { controller = "User", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Login",
                url: "dang-nhap",
                defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Search",
                url: "tim-kiem",
                defaults: new { controller = "ProductClient", action = "Search", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
