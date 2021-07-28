using EshopMVC.Areas.Admin.Data;
using Model.Entity;
using Model.Function;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EshopMVC.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
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
                    //Get posted image file
                    string ImageName = Path.GetFileName(file.FileName);
                    string FolderPath = Server.MapPath("~/Content/Image/" + ImageName);
                    file.SaveAs(FolderPath);
                    model.ProductImage = ImageName;

                    var item = new PRODUCT
                    {
                        PRODUTNAME = model.ProductName,
                        PRODUCTCATEGORY = model.ProductCategory,
                        PRODUCTPRICE = model.ProductPrice,
                        PRODUCTIMAGE = model.ProductImage,
                        PRODUCTDESC = model.ProductDesc
                    };

                    var InsertDb = function.InsertProduct(item);
                    if (InsertDb != null)
                    {
                        ModelState.AddModelError("", "Thêm sản phẩm thành công");
                        SetProductList();
                        ModelState.Clear();
                        return View("Create");
                    }
                }
            }
            ModelState.AddModelError("", "Vui lòng nhập thông tin sản phẩm");
            SetProductList();
            return View("Create");
        }

        public void SetProductList(int? SelectCategory = null)
        {
            var item = new ProductFunction();
            ViewBag.ProductCategory = new SelectList(item.ListCategory(), "CATEGORYID", "CATEGORYNAME", SelectCategory);
        }
    }
}
