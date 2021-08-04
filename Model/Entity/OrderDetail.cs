namespace Database.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        [Key]
        [Column(Order = 0)]
        public int ProductId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}