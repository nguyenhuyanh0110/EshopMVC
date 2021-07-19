﻿using EshopMVC.Areas.Admin.Data;
using Model;
using Model.Entity;
using Model.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EshopMVC.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //create a json list passing data to jsGrid
        public JsonResult GetCategory()
        {
            using (OnlineShopDbContext db = new OnlineShopDbContext())
            {
                //LinQ to query Category List
                var Result = db.CATEGORY.Select(a => new
                {
                    a.CATEGORYID,
                    a.CATEGORYNAME
                }).ToList();
                var JsonCategory = Result;
                return Json(JsonCategory, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Category/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryModel model)
        {
            
            if (ModelState.IsValid)
            {
                var category = new CategoryFunction();
                if(category.CheckCategory(model.CategoryName))
                {
                    ModelState.AddModelError("", "Danh mục sản phẩm đã có");
                }
                else
                {
                    var CreateCategory = new CATEGORY();
                    CreateCategory.CATEGORYNAME = model.CategoryName;
                    var Result = category.InsertCategory(CreateCategory);
                    if(Result != null)
                    {
                        ModelState.AddModelError("", "Thêm danh mục sản phẩm thành công");
                        ModelState.Clear();
                        return View("Index");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Thêm sản phẩm không thành công");
            }
            return View("Index");
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int id)
        {
            var category = new CategoryFunction();
            var FindCategory = category.GetCategory(id);
            return View(FindCategory);
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
