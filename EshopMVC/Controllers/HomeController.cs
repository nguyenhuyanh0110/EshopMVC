using EshopMVC.Helper.Session;
using EshopMVC.Models;
using Model.Function.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EshopMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [OutputCache(Duration = 3600)]
        public ActionResult Index()
        {
            ViewBag.Slide = new SlideFunction().ListSlide();
            var product = new ProductFunction();
            ViewBag.NewProduct = product.ListNewProduct(6);
            ViewBag.TrendingProduct = product.ListTrendingProduct(4);
            ViewBag.Promotion = new ProductFunction().ListPromotion(6);
            return View();
        }

        //use for partial view
        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public ActionResult TopMenu()
        {
            var Menu = new MenuFunction().ListMenu(1);
            return PartialView(Menu);
        }
        
        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            
            //get session cart pass to Index
            var Cart = Session[SetSession.CartSession];
            var List = new List<CartModel>();
            if(Cart != null)
            {
                List = (List<CartModel>)Cart;
            }
            return PartialView(List);
        }
    }
}