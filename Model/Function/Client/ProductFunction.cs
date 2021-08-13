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

        public CategoryMenu Breakcrumb(long id)
        {
            return db.CategoryMenu.Find(id);
        }

        public List<CategoryMenu> ListCategoryOption(long id)
        {
            return db.CategoryMenu.Where(a => a.ParentId == id).ToList();
        }

        public PRODUCT ProductDetail(long id)
        {
            return db.PRODUCT.Find(id);
        }

        public List<string> ListName(string keyword)
        {
            return db.PRODUCT.Where(a => a.PRODUCTNAME.Contains(keyword)).Select(a => a.PRODUCTNAME).ToList();
        }

        public List<PRODUCT> FindByName(string name)
        {
            return db.PRODUCT.Where(a => a.PRODUCTNAME.Contains(name)).ToList();
        }
    }
}
