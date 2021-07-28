using Model.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Model.Function
{
    public class ProductFunction
    {
        OnlineShopDbContext db = new OnlineShopDbContext();

        public List<CATEGORY> ListCategory()
        {
            return db.CATEGORY.ToList();
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
