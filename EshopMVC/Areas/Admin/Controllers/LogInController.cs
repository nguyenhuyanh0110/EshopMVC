using EshopMVC.Areas.AdminArea.Data;
using System.Web.Mvc;
using Model;
using EshopMVC.Areas.AdminArea.Code;
using System.Web.Security;

namespace EshopMVC.Areas.Admin.Controllers
{
    public class LogInController : Controller
    {
        // GET: AdminArea/LogIn
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //measure client token match with server token
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            //create a variable to take data from model
            var result = new UserModel().Login(model.UserName, model.Password);
            //using membership method by web.security to validate users
            if (result && ModelState.IsValid)
            {
                //if log in success it will take the session of user and redirect the page
                SessionHelper.SetSession(new UserSession() { UserName = model.UserName });
                //redirect to homapage with username
                return RedirectToAction("AdminHome", "AdminHome");
            }
            else
            {
                //there is no account, it will send an error massage
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
            }
            return View("Index");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}