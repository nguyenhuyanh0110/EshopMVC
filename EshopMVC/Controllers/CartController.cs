using EshopMVC.Helper.Session;
using EshopMVC.Models;
using Model.Function.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace EshopMVC.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            var Cart = Session[SetSession.CartSession];
            var ListItem = new List<CartModel>();
            if(Cart != null)
            {
                ListItem = (List<CartModel>)Cart;
            }
            return View(ListItem);
        }

        public ActionResult AddItem(int Id, int Quantity)
        {
            var session = Session[SetSession.CartSession];
            var ProductModel = new ProductFunction().ProductDetail(Id);
            if (session != null)
            {
                var ListItem = (List<CartModel>)session;
                //if have item will insert quantity
                if(ListItem.Exists(a => a.Product.PRODUCTID == Id))
                {
                    foreach (var item in ListItem)
                    {
                        if (item.Product.PRODUCTID == Id)
                        {
                            item.Quantity += Id;
                        }
                    }
                }
                //no item add new product
                else
                {
                    var item = new CartModel();
                    item.Product = ProductModel;
                    item.Quantity = Quantity;
                    ListItem.Add(item);
                }
            }
            else
            {
                //insert new item to cart model
                var item = new CartModel();
                item.Product = ProductModel;
                item.Quantity = Quantity;
                //Add into session
                var ListItem = new List<CartModel>();
                ListItem.Add(item);
                Session[SetSession.CartSession] = ListItem;
            }
            return RedirectToAction("Index","Home");
        }

        public JsonResult IncreaseQuantity(string CartModel)
        {
            var json = new JavaScriptSerializer().Deserialize<List<CartModel>>(CartModel);
            var session = (List<CartModel>)Session[SetSession.CartSession];
            foreach(var item in session)
            {
                var jsonItem = json.SingleOrDefault(a => a.Product.PRODUCTID == item.Product.PRODUCTID);
                if(jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[SetSession.CartSession] = session;
            return Json(new { status = true });
        }

        public JsonResult DeleteItem(long Id)
        {
            var session = (List<CartModel>)Session[SetSession.CartSession];
            session.RemoveAll(a => a.Product.PRODUCTID == Id);
            Session[SetSession.CartSession] = session;
            return Json(new { status = true });
        }

        public ActionResult Checkout()
        {
            return View();
        }
    }
}