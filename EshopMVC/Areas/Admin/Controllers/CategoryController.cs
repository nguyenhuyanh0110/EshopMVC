using EshopMVC.Areas.Admin.Data;
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
    public class CategoryController : CheckSessionController
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

        // POST: Admin/Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryModel model)
        {
            var category = new CategoryFunction();

            if (ModelState.IsValid)
            {

                if (category.CheckCategory(model.CategoryName))
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
                ModelState.AddModelError("", "Vui lòng nhập danh mục");
                ModelState.Clear();
            }
            return View("Index");
        }

        [HttpPost]
        // GET: Admin/Category/Edit/5
        //using direct table database because on the front-end doesnt have editor for value
        public JsonResult Edit(CATEGORY model)
        {
            var category = new CategoryFunction();

            if (ModelState.IsValid)
            {
                var Result = category.EditCategory(model);
                if (Result)
                {
                    ModelState.AddModelError("", "Thêm danh mục sản phẩm thành công");
                    ModelState.Clear();
                    return Json(Result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    ModelState.AddModelError("", "Thêm sản phẩm không thành công");
                    ModelState.Clear();
                }
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost]
        public JsonResult Delete(int CategoryId)
        {
            var item = new CategoryFunction();
            var delete = item.DeleteCategory(CategoryId);
            return Json(delete, JsonRequestBehavior.AllowGet); 
        }
    }
}
