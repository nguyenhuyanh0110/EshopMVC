using Model.Function;
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
        public ActionResult Index()
        {
            ViewBag.Slide = new SlideFunction().ListSlide();
            return View();
        }

        //use for partial view
        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            var Menu = new MenuFunction().ListMenu(1);
            return PartialView(Menu);
        }
    }
}