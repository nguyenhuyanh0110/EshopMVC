namespace Database.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CategoryMenu")]
    public partial class CategoryMenu
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string MetaTitle { get; set; }

        public int? ParentId { get; set; }

        public int DisplayOrder { get; set; }

        public bool Status { get; set; }
    }
}
