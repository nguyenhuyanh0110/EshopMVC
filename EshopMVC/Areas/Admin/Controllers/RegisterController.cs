using EshopMVC.Areas.AdminArea.Data;
using Model.Entity;
using Model.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EshopMVC.Areas.Admin.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Admin/Register
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register(USERINFO model)
        {
            var user = new Function();
            string UserName = user.InsertUser(model);
            if (UserName != null)
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                ModelState.AddModelError("", "Tài khoản đã được đăng ký");
            }
            return View("Index");
        }
    }
}