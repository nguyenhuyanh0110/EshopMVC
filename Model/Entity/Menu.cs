namespace Database.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        public int MenuId { get; set; }

        [Required]
        public string MenuName { get; set; }

        [Required]
        [StringLength(50)]
        public string MenuLink { get; set; }

        public int MenuDisplay { get; set; }

        [Required]
        [StringLength(50)]
        public string MenuStatus { get; set; }

        public int GroupId { get; set; }
    }
}
