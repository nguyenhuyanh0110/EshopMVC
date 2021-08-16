namespace Database.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GroupUser")]
    public partial class GroupUser
    {
        public string Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
