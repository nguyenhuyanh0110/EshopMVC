using Database.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Model.Function
{
    public class ProductFunction
    {
        OnlineShopDbContext db = new OnlineShopDbContext();

        public List<CATEGORY> ListCategory()
        {
            return db.CATEGORY.ToList();
        }

        public List<PRODUCT> ListProduct()
        {
            return db.PRODUCT.ToList();
        }

        public bool CheckProduct(string Product)
        {
            var item = db.PRODUCT.Where(a => a.PRODUTNAME == Product);
            if (item.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string InsertProduct(PRODUCT item)
        {
            db.PRODUCT.Add(item);
            db.SaveChanges();
            return item.PRODUTNAME;
        }
    }
}
