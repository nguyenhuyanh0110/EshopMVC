namespace Database.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRODUCT")]
    public partial class PRODUCT
    {
        public int PRODUCTID { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [StringLength(500)]
        public string PRODUCTNAME { get; set; }

        [Display(Name = "Giá sản phẩm")]
        public int PRODUCTPRICE { get; set; }

        [Display(Name = "Hình ảnh sản phẩm")]
        [StringLength(250)]
        public string PRODUCTIMAGE { get; set; }

        [Display(Name = "Danh mục sản phẩm")]
        public int PRODUCTCATEGORY { get; set; }

        [Display(Name = "Mô tả sản phẩm")]
        public string PRODUCTDESC { get; set; }
    }
}
