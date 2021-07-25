﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EshopMVC.Areas.Admin.Data
{
    public class Register
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage ="Vui lòng nhập tên tài khoản")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Vui lòng nhập mật khẩu")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Vui lòng xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage ="Mật khẩu xác nhận không đúng")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage ="Vui lòng nhập Họ Tên")]
        public string HoTen { get; set; }

        [Required(ErrorMessage ="Vui lòng nhập số điện thoại")]
        public string Sdt { get; set; }

        [Required(ErrorMessage ="Vui lòng nhập Email")]
        public string Email { get; set; }
    }
}