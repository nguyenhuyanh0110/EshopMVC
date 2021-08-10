using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EshopMVC.Models
{
    public class InvoiceModel
    {
        public Order order { get; set; }
    }
}