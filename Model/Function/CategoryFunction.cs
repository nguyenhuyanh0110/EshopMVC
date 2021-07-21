using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Function
{
    public class CategoryFunction
    {
        OnlineShopDbContext db = new OnlineShopDbContext();

        public string InsertCategory(CATEGORY category)
        {
            db.CATEGORY.Add(category);
            db.SaveChanges();
            return category.CATEGORYNAME;
        }

        public CATEGORY GetCategory(int category)
        {
            return db.CATEGORY.SingleOrDefault(a => a.CATEGORYID == category);
        }

        public bool CheckCategory(string CategoryName)
        {
            var category = db.CATEGORY.Where(a => a.CATEGORYNAME == CategoryName);
            if (category.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditCategory(CATEGORY category)
        {
            try
            {
                var list = db.CATEGORY.Find(category.CATEGORYID);
                list.CATEGORYNAME = category.CATEGORYNAME;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCategory(int id)
        {
            try
            {
                var category = db.CATEGORY.Find(id);
                db.CATEGORY.Remove(category);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
