using EshopMVC.Areas.Admin.Data;
using Model.Entity;
using Model.Function;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser(Register model)
        {
            //if form is not null
            if(ModelState.IsValid)
            {
                var user = new UserFunction();
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
                    //add to table UserInfo by Model view
                    var CreateUser = new USERINFO();
                    CreateUser.USERNAME = model.UserName;
                    CreateUser.PASSWORD = Security.Md5Hash(model.Password);
                    CreateUser.HOTEN = model.HoTen;
                    CreateUser.SODT = model.Sdt;
                    CreateUser.EMAIL = model.Email;
                    var Result = user.InsertUser(CreateUser);
                    if (Result != null)
                    {
                        ModelState.AddModelError("", "Đăng ký thành công");
                        //reset form after success
                        ModelState.Clear();
                        return RedirectToAction("Index", "LogIn");
                    }  
                }
            }
            else
            {
                ModelState.AddModelError("", "Đăng ký không thành công");
            }
            return View("Index");
        }
    }
}