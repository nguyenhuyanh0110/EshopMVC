using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EshopMVC.Models
{
    [Serializable]
    public class CartModel
    {
        public PRODUCT Product { get; set; }
        public int Quantity { get; set; }
    }
}