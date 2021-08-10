using Database.Entity;
using Email;
using EshopMVC.Helper.Session;
using EshopMVC.Models;
using Model.Function.Client;
using PayPal.Api;
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
            if (Cart != null)
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
                if (ListItem.Exists(a => a.Product.PRODUCTID == Id))
                {
                    foreach (var item in ListItem)
                    {
                        if (item.Product.PRODUCTID == Id)
                        {
                            item.Quantity += Id;
                        }
                    }
                }
                //already have session but no same item
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
            return RedirectToAction("Index", "Home");
        }

        public JsonResult IncreaseQuantity(string CartModel)
        {
            var json = new JavaScriptSerializer().Deserialize<List<CartModel>>(CartModel);
            var session = (List<CartModel>)Session[SetSession.CartSession];
            foreach (var item in session)
            {
                var jsonItem = json.SingleOrDefault(a => a.Product.PRODUCTID == item.Product.PRODUCTID);
                if (jsonItem != null)
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

        [HttpGet]
        public ActionResult Checkout()
        {
            var Cart = Session[SetSession.CartSession];
            var ListItem = new List<CartModel>();
            if (Cart != null)
            {
                ListItem = (List<CartModel>)Cart;
            }
            return View(ListItem);
        }

        [HttpPost]
        //pass data direct from view, not Model
        public ActionResult Checkout(string ShipName, string ShipMobile, string ShipAddress, string ShipEmail)
        {
            decimal total = 0;
            var item = new Database.Entity.Order
            {
                CreatedDate = DateTime.Now,
                ShipName = ShipName,
                ShipMobile = ShipMobile,
                ShipAddress = ShipAddress,
                ShipEmail = ShipEmail
            };
            try
            {
                var order = new OrderFunction().InsertOrder(item);

                //get Order information to session for preview invoice
                var OrderSession = new List<Database.Entity.Order>();
                OrderSession.Add(item);
                Session[SetSession.OrderSession] = OrderSession;

                //add data to OderDetail by cart session
                var CartSession = (List<CartModel>)Session[SetSession.CartSession];
                foreach (var ItemSession in CartSession)
                {
                    var OrderDetail = new OrderDetail
                    {
                        ProductId = ItemSession.Product.PRODUCTID,
                        OrderId = item.Id,
                        Price = ItemSession.Product.PRODUCTPRICE,
                        Quantity = ItemSession.Quantity
                    };
                    var detail = new OrderFunction().InsertOderDeatail(OrderDetail);
                    total += (ItemSession.Product.PRODUCTPRICE * ItemSession.Quantity);
                };
                try
                {
                    //create content for sending email
                    string content = System.IO.File.ReadAllText(Server.MapPath("~/Content/assets/Email/Email.html"));
                    content = content.Replace("{{CustomerName}}", ShipName);
                    content = content.Replace("{{Email}}", ShipEmail);
                    content = content.Replace("{{Phone}}", ShipMobile);
                    content = content.Replace("{{Address}}", ShipAddress);
                    content = content.Replace("{{Total}}", total.ToString("N0"));
                    new EmailHelper().Email(ShipEmail, "Xác nhận đơn hàng từ EShop", content);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Redirect("/hoa-don");
        }

        [HttpGet]
        public ActionResult Invoice()
        {
            //get session product
            var session = Session[SetSession.OrderSession];
            var Info = new List<Database.Entity.Order>();
            Info = (List<Database.Entity.Order>)session;
            if (session != null)
            {
                Info = (List<Database.Entity.Order>)session;
            }
            else
            {
                return Redirect("/error");
            }
            return View(Info);
        }

        public PartialViewResult OrderPartialInvoice()
        {
            var Cart = Session[SetSession.CartSession];
            var ListItem = new List<CartModel>();
            ListItem = (List<CartModel>)Cart;
            if (Cart != null)
            {
                ListItem = (List<CartModel>)Cart;
            }
            return PartialView(ListItem);
        }

        //create Paypal variable
        private Payment payment;

        //create payment use APIPaypal
        private Payment CreatePayment(APIContext api, string redirUrl)
        {
            var ListItem = new ItemList()
            {
                items = new List<Item>()
            };

            List<CartModel> CartSession = (List<CartModel>)Session[SetSession.CartSession];
            foreach(var item in CartSession)
            {
                ListItem.items.Add(new Item()
                {
                    name = item.Product.PRODUCTNAME,
                    currency = "USD",
                    price = item.Product.PRODUCTPRICE.ToString(),
                    quantity = item.Quantity.ToString(),
                    sku = "sku"
                });
            }

            var payer = new Payer()
            {
                payment_method = "paypal"
            };

            var _redirUrl = new RedirectUrls()
            {
                cancel_url = redirUrl,
                return_url = redirUrl
            };

            var detail = new Details()
            {
                tax = "10",
                shipping = "20",
                subtotal = CartSession.Sum(a => a.Product.PRODUCTPRICE * a.Quantity).ToString()
            };

            var amount = new Amount()
            {
                currency = "USD",
                total = (Convert.ToDouble(detail.tax) + Convert.ToDouble(detail.shipping) + Convert.ToDouble(detail.subtotal)).ToString(),
                details = detail
            };

            var transaction = new List<Transaction>();
            transaction.Add(new Transaction()
            {
                description = "This is Paypal",
                invoice_number = Convert.ToString((new Random()).Next(100000)),
                amount = amount,
                item_list = ListItem
            });

            payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transaction,
                redirect_urls = _redirUrl
            };

            return payment.Create(api);
        }

        private Payment Execute(APIContext api, string payerId, string paymentId)
        {
            var excute = new PaymentExecution()
            {
                payer_id = payerId
            };
            payment = new Payment() { id = paymentId };
            return payment.Execute(api, excute);
        }

        public ActionResult PaymentWithPaypal()
        {
            APIContext api = PaypalConfiguration.GetAPIContext();

            try
            {
                string payerId = Request.Params["payerID"];
                if(string.IsNullOrEmpty(payerId))
                {
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/Cart/PaymentWithPaypal?";
                    var guid = Convert.ToString((new Random()).Next(100000));
                    var createdPayment = CreatePayment(api, baseURI + "guid=" + guid);

                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = string.Empty;

                    while (links.MoveNext())
                    {
                        Links link = links.Current;
                        if (link.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            paypalRedirectUrl = link.href;
                        }
                    }

                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    // This one will be executed when we have received all the payment params from previous call
                    var guid = Request.Params["guid"];
                    var executedPayment = Execute(api, payerId, Session[guid] as string);
                    if (executedPayment.state.ToLower() != "approved")
                    {
                        Session.RemoveAll();
                        //Remove shopping cart session
                        return View("Failure");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            Session.RemoveAll();
            return View("Success");
        }
    }
}