using System.Web.Mvc;
using EshopMVC.Areas.AdminArea.Code;
using EshopMVC.Areas.Admin.Code;
using EshopMVC.Areas.Admin.Data;
using Model.Function.Admin;
using Model.Function;

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
            if(ModelState.IsValid)
            {
                var Result = new UserFunction();
                var AdminVerify = Result.Login(model.UserName, Security.Md5Hash(model.Password));
                if(AdminVerify)
                {
                    //take UserInfo to save for session
                    var GetUserInfo = Result.GetUserInfo(model.UserName);
                    UserSession UserSession = new UserSession();
                    UserSession.UserName = GetUserInfo.USERNAME;
                    Session.Add(SaveSession.UserSession, UserSession);
                    return RedirectToAction("AdminHome", "AdminHome");
                }
                else
                {
                    ModelState.AddModelError("", "Sai thông tin hoặc mật khẩu");
                }
            }
            else
            {
                ModelState.AddModelError("", "Vui lòng nhập thông tin");
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