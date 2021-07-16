using EshopMVC.Areas.Admin.Code;
using EshopMVC.Areas.AdminArea.Code;
using Model.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EshopMVC.Areas.Admin.Controllers
{
    public class CheckSessionController : Controller
    {
        //CheckSession if User not login will redirect to login
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = (UserSession)Session[SaveSession.UserSession];
            if(session == null)
            {
                //if there is no session will redirect to LogIn Fucntion until Login success
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Admin"}));
            }
            base.OnActionExecuted(filterContext);
        }
    }
}