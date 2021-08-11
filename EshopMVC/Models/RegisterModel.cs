using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EshopMVC.Models
{
    public class Register
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name ="Tên tài khoản")]
        [Required(ErrorMessage ="Vui lòng nhập tên tài khoản")]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage ="Vui lòng nhập mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Required(ErrorMessage ="Vui lòng xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage ="Mật khẩu xác nhận không đúng")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage ="Vui lòng nhập Họ Tên")]
        public string HoTen { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage ="Vui lòng nhập số điện thoại")]
        public string Sdt { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage ="Vui lòng nhập Email")]
        public string Email { get; set; }
    }
}