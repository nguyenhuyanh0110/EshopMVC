using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EshopMVC.Areas.Admin.Data
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }

        [Display(Name ="Tên danh mục sản phẩm")]
        [Required(ErrorMessage ="Vui lòng nhập tên danh mục")]
        public string CategoryName { get; set; }
    }
}