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

        [StringLength(500)]
        public string PRODUTNAME { get; set; }

        public int? PRODUCTPRICE { get; set; }

        [StringLength(250)]
        public string PRODUCTIMAGE { get; set; }

        public int PRODUCTCATEGORY { get; set; }

        [StringLength(1000)]
        public string PRODUCTDESC { get; set; }
    }
}
