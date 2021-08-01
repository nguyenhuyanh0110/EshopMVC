using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Function
{
    public class CategoryMenu
    {
        OnlineShopDbContext db = new OnlineShopDbContext();

        public List<ProductCategory> ListCategory()
        {
            return db.ProductCategory.Where(a => a.Status == true).ToList();
        }
    }
}
