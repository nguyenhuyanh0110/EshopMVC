using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Function.Client
{
    public class ProductFunction
    {
        OnlineShopDbContext db = new OnlineShopDbContext();
        public List<PRODUCT> ListNewProduct(int quantity)
        {
            return db.PRODUCT.OrderByDescending(a => a.CreatedDate).Take(quantity).ToList();
        }

        public List<PRODUCT> ListTrendingProduct(int quantity)
        {
            return db.PRODUCT.Where(a => a.TrendingDate != null && a.TrendingDate > DateTime.Now).OrderByDescending(a => a.CreatedDate).Take(quantity).ToList();
        }

        public PRODUCT ProductDetail(long id)
        {
            return db.PRODUCT.Find(id);
        }
    }
}
