using Database.Entity;
using Model.Function.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EshopMVC.Controllers
{
    public class ProductCategoryController : Controller
    {
        // GET: ProductCategory
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult ProductCategory()
        {
            var product = new CategoryMenu().ListCategory();
            return PartialView(product);
        }

        public ActionResult ProductDetail(long id)
        {
            var detail = new ProductFunction().ProductDetail(id);
            ViewBag.Related = new ProductFunction().ListNewProduct(6);
            return View(detail);
        }
    }
}