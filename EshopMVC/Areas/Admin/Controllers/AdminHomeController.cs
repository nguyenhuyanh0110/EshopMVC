using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EshopMVC.Areas.Admin.Controllers
{
    public class AdminHomeController : CheckSessionController
    {
        // GET: Admin/AdminHome
        public ActionResult AdminHome()
        {
            return View();
        }
    }
}