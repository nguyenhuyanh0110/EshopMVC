﻿namespace Database.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Table("Order")]
    public partial class Order
    {
        public int Id { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string ShipName { get; set; }

        public string  ShipMobile { get; set; }

        public string ShipAddress { get; set; }

        public string ShipEmail { get; set; }

        public bool? Status { get; set; }

    }
}