namespace Database.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MenuType")]
    public partial class MenuType
    {
        [Key]
        public int GroupMenuId { get; set; }

        [Required]
        [StringLength(50)]
        public string GroupMenuName { get; set; }
    }
}
