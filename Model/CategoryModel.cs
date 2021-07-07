using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CategoryModel
    {
        private OnlineShopDbContext context = null;

        public CategoryModel()
        {
            context = new OnlineShopDbContext();
        }

        public List<CATEGORY> ListAll()
        {
            //create a variable to query from database by procedure
            var list = context.Database.SqlQuery<CATEGORY>("CATEGORY_LIST").ToList();
            return list;
        }
    }
}
