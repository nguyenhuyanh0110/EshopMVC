﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EshopMVC.Controllers
{
    public class NotFoundController : Controller
    {
        // GET: NotFound
        public ActionResult Index()
        {
            return View();
        }
    }
}