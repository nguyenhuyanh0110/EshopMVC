using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EshopMVC.Areas.AdminArea.Data
{
    //create a model log in take data from controller Login
    public class LoginModel
    {
        [Required(ErrorMessage = "Vui lòng nhập thông tin tài khoản")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}