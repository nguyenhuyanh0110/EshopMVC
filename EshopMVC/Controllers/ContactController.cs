using Database.Entity;
using Model.Function.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EshopMVC.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            var model = new ContactFunction();
            return View(model);
        }

        [HttpPost]
        public JsonResult Send(string name, string phone, string message, string email)
        {
            var fb = new Feedback()
            {
                Name = name,
                Phone = phone,
                Email = email,
                Message = message,
                CreatedDate = DateTime.Now
            };

            var insert = new ContactFunction().FeedBack(fb);
            if(insert > 0)
            {
                return Json(new { status = true });
            }
            else
            {
                return Json(new { status = false });
            }
        }
    }
}