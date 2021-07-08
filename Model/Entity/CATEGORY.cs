namespace Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CATEGORY")]
    public partial class CATEGORY
    {
        [DisplayName("Mã số danh mục")]
        public int CATEGORYID { get; set; }

        [StringLength(250)]
        [DisplayName("Tên danh mục")]
        [Required(ErrorMessage = ("Vui lòng điền vào danh mục"))]
        public string CATEGORYNAME { get; set; }
    }
}
