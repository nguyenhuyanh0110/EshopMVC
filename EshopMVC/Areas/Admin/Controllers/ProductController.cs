using Database.Entity;
using EshopMVC.Areas.Admin.Data;
using EshopMVC.Areas.Admin.Helper;
using Model.Function.Admin;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace EshopMVC.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {

        [HttpGet]
        public ActionResult Index()
        {
            var GetProduct = new ProductFunction();
            var item = GetProduct.ListProduct();
            return View(item);
        }

        [HttpGet]
        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            //set view bag to send data category id to product
            SetProductList();
            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]
        public ActionResult Create(ProductModel model, HttpPostedFileBase file)
        {
            var function = new ProductFunction();
            if (ModelState.IsValid || file != null)
            {
                if (function.CheckProduct(model.ProductName))
                {
                    ModelState.AddModelError("", "Đã có thông tin sản phẩm");
                }
                else
                {
                    var Image = new ImageHelper();
                    model.ProductImage = Image.GetImage(file);

                    var item = new PRODUCT
                    {
                        PRODUCTNAME = model.ProductName,
                        PRODUCTCATEGORY = model.ProductCategory,
                        PRODUCTPRICE = model.ProductPrice,
                        PRODUCTIMAGE = model.ProductImage,
                        PRODUCTDESC = model.ProductDesc,
                        CreatedDate = DateTime.Now,
                        SubMenu = model.SubMenu
                    };
                    var InsertDb = function.InsertProduct(item);
                    if (InsertDb != null)
                    {
                        SetAlert("Thêm sản phẩm thành công", "success");
                        SetProductList();
                        return View(model);
                    }
                }
            }
            ModelState.AddModelError("", "Vui lòng nhập thông tin sản phẩm");
            SetProductList();
            return View("Create");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            SetProductList();
            var function = new ProductFunction();
            var item = function.GetProduct(Id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(PRODUCT model, int id, HttpPostedFileBase file)
        {
            SetProductList();
            var function = new ProductFunction();
            model.PRODUCTID = id;
            if (ModelState.IsValid)
            {
                if(file != null)
                {
                    var Image = new ImageHelper();
                    model.PRODUCTIMAGE = Image.GetImage(file);
                }
                var edit = function.EditProduct(model, model.PRODUCTID);
                if (edit)
                {
                    SetAlert("Sửa đổi sản phẩm thành công", "success");
                    var list = function.ListProduct();
                    return View("Index", list);
                }
                else
                {
                    ModelState.AddModelError("", "Sửa đổi phẩm không thành công");
                    ModelState.Clear();
                }
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var delete = new ProductFunction();
            var item = delete.DeleteProduct(id);
            var list = delete.ListProduct();
            return View("Index", list);
        }

        public void SetProductList(int? SelectCategory = null)
        {
            var item = new ProductFunction();
            ViewBag.ProductCategory = new SelectList(item.ListCategory(), "CATEGORYID", "CATEGORYNAME", SelectCategory);
        }

        public JsonResult SubMenu(int? id)
        {
            var name = new ProductFunction().SubMenu(id);
            var SubId = new ProductFunction().SubMenuId(id);
            return Json(new { status = true, id = SubId ,SubName = name}, JsonRequestBehavior.AllowGet);
        }
    }
}
