namespace Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USERINFO")]
    public partial class USERINFO
    {
        [Key]
        public int USERID { get; set; }

        [Required]
        [StringLength(100)]
        public string HOTEN { get; set; }

        [StringLength(10)]
        public string SODT { get; set; }

        [StringLength(100)]
        public string EMAIL { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thông tin tài khoản")]
        [StringLength(50)]
        public string USERNAME { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [StringLength(50)]
        public string PASSWORD { get; set; }
    }
}
