using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Function.Client
{
    public class CategoryList
    {
        OnlineShopDbContext db = new OnlineShopDbContext();

        public List<CategoryMenu> ListCategory()
        {
            return db.CategoryMenu.Where(a => a.Status == true).ToList();
        }
    }
}
