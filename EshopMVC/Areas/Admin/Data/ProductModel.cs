using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EshopMVC.Areas.Admin.Data
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name ="Tên sản phẩm")]
        [Required(ErrorMessage ="Vui lòng nhập tên sản phẩm")]
        public string ProductName { get; set; }

        [Display(Name ="Danh mục sản phẩm")]
        [Required(ErrorMessage ="Vui lòng chọn danh mục sản phẩm")]
        public int ProductCategory { get; set; }

        [Display(Name = "Giá sản phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập giá sản phẩm")]
        public int ProductPrice { get; set; }

        [Display(Name ="Hình ảnh sản phẩm")]
        [Required(ErrorMessage = "Vui lòng chọn hình ảnh sản phẩm")]
        public string ProductImage { get; set; }

        [Display(Name ="Mô tả sản phẩm")]
        public string ProductDesc { get; set; }
    }
}