using Database.Entity;
using EshopMVC.Areas.Admin.Data;
using Model.Function.Client;
using System.Web.Mvc;
using Model.Function;
using EshopMVC.Models;
using BotDetect.Web.Mvc;
using LoginModel = EshopMVC.Models.LoginModel;
using EshopMVC.Helper.Session;

namespace EshopMVC.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [CaptchaValidationActionFilter("CaptchaCode", "RegisterCaptcha", "Mã Captcha không hợp lệ")]
        public ActionResult Register(Register model)
        {
            //// get user input value
            //string userInput = HttpContext.Request.Form["CaptchaCode"];
            //// init mvcCaptcha instance with captchaId
            //MvcCaptcha mvcCaptcha = new MvcCaptcha("RegisterCaptcha");
            //if form is not null
            if (ModelState.IsValid)
            {
                var user = new UserClientFunction();
                if (user.CheckUserInfo(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (user.CheckUserInfo(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var insert = new USERINFO()
                    {
                        HOTEN = model.HoTen,
                        USERNAME = model.UserName,
                        EMAIL = model.Email,
                        SODT = model.Sdt,
                        PASSWORD = Security.Md5Hash(model.Password)
                    };
                    var Result = new UserClientFunction().InsertUser(insert);
                    if (Result > 0)
                    {
                        ModelState.AddModelError("", "Đăng ký thành công");
                        //reset form after success
                        ModelState.Clear();
                        return Redirect("/");
                    }
                }
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                var function = new UserClientFunction();
                var user = function.Login(model.UserName, Security.Md5Hash(model.Password));
                if(user)
                {
                    //get user info add to session
                    var info = function.GetUserInfo(model.UserName);
                    var UserSession = new LoginModel
                    {
                        UserName = info.USERNAME,
                        UserId = info.USERID
                    };
                    Session.Add(SetSession.UserSession, UserSession);
                }
                else
                {
                    ModelState.AddModelError("", "Sai thông tin hoặc mật khẩu");
                }
            }
            else
            {
                ModelState.AddModelError("", "Vui lòng nhập thông tin");
                return View("Login");
            }
            return Redirect("/");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return Redirect("/");
        }
    }
}