namespace Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CATEGORY")]
    public partial class CATEGORY
    {
        public int CATEGORYID { get; set; }

        [Required]
        [StringLength(250)]
        public string CATEGORYNAME { get; set; }
    }
}
