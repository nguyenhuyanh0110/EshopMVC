﻿using Database.Entity;
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
            var product = new CategoryList().ListCategory();
            return PartialView(product);
        }

        public ActionResult ProductDetail(long id)
        {
            var detail = new ProductFunction().ProductDetail(id);
            ViewBag.Related = new ProductFunction().ListNewProduct(6);
            return View(detail);
        }

        public ActionResult ListProduct(long id)
        {
            var ListProduct = new ProductFunction().ProductDetail(id);
            ViewBag.CategoryName = new ProductFunction().Breakcrumb(id);
            ViewBag.Option = new ProductFunction().ListCategoryOption(id);
            ViewBag.NewProduct = new ProductFunction().ListNewProduct(4);
            return View(ListProduct);
        }
    }
}