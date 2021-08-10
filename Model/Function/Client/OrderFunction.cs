using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Function.Client
{
     public class OrderFunction
    {
        OnlineShopDbContext db = new OnlineShopDbContext();

        public OrderDetail FindOrderById(long id)
        {
            return db.OrderDetail.Find(id);
        }

        public long InsertOrder(Order order)
        {
            db.Order.Add(order);
            db.SaveChanges();
            return order.Id;
        }

        public bool InsertOderDeatail(OrderDetail detail)
        {
            try
            {
                db.OrderDetail.Add(detail);
                db.SaveChanges();
                return true;
            }catch
            {
                return false;
            }
        }
    }
}
