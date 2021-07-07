namespace Model.Entity
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

        [StringLength(1000)]
        public string PRODUCTNAME { get; set; }

        public int? PRODUCTPRICE { get; set; }

        [StringLength(250)]
        public string PRUDUCTIMAGE { get; set; }
    }
}
