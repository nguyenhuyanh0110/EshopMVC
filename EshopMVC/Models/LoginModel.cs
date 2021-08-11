using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EshopMVC.Models
{
    [Serializable]
    public class LoginModel
    {
        [Key]
        [Required(ErrorMessage ="Vui lòng nhập tên đăng nhập")]
        [Display(Name ="Tên đăng nhập")]
        public string UserName { get; set; }

        public long UserId { get; set; }

        [Required(ErrorMessage ="Vui lòng nhập mật khẩu")]
        [Display(Name ="Mật khẩu")]
        public string Password { get; set; }
    }
}