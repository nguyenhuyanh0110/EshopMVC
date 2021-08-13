using EshopMVC.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Function.Client;
using System;
using System.Web.Mvc;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
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
            if (ModelState.IsValid)
            {
                var function = new UserClientFunction();
                var user = function.Login(model.UserName, Security.Md5Hash(model.Password));
                if (user)
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

        //Call Api facebook
        private Uri CallApi
        {
            get
            {
                var UriBuilder = new UriBuilder(Request.Url);
                UriBuilder.Query = null;
                UriBuilder.Fragment = null;
                UriBuilder.Path = Url.Action("FacebookCallBack");
                return UriBuilder.Uri;
            }
        }

        //receive Callback from Fb
        public ActionResult FacebookCallBack(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FbId"],
                client_secret = ConfigurationManager.AppSettings["FbKey"],
                redirect_uri = CallApi.AbsoluteUri,
                code = code
            });
            var token = result.access_token;
            if (!string.IsNullOrEmpty(token))
            {
                fb.AccessToken = token;
                dynamic info = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
                string email = info.email;
                string UserName = info.email;
                string FirstName = info.first_name;
                string MiddleName = info.middle_name;
                string LastName = info.last_name;

                var user = new USERINFO()
                {
                    EMAIL = email,
                    USERNAME = email,
                    HOTEN = FirstName + "" + MiddleName + "" + LastName
                };
                var insert = new UserClientFunction().InsertUser(user);
                if (insert > 0)
                {
                    var UserSession = new LoginModel()
                    {
                        UserName = user.USERNAME,
                        Password = user.PASSWORD
                    };
                    Session.Add(SetSession.UserSession, UserSession);
                }
            }
            return Redirect("/");
        }

        public ActionResult LoginFb()
        {
            var fb = new FacebookClient();
            var LoginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FbId"],
                client_secret = ConfigurationManager.AppSettings["FbKey"],
                redirect_uri = CallApi.AbsoluteUri,
                respone_type = "code",
                scope = "email"
            });
            return Redirect(LoginUrl.AbsoluteUri);
        }
    }
}
