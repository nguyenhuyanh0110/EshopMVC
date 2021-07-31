using Database.Entity;
using System;
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

        public PRODUCT GetProduct(int id)
        {
            return db.PRODUCT.SingleOrDefault(a => a.PRODUCTID == id);
        }

        public bool CheckProduct(string Product)
        {
            var item = db.PRODUCT.Where(a => a.PRODUCTNAME == Product);
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
            return item.PRODUCTNAME;
        }

        public bool EditProduct(PRODUCT model, int product)
        {
            try
            {
                var item = db.PRODUCT.Find(product);
                item.PRODUCTNAME = model.PRODUCTNAME;
                item.PRODUCTCATEGORY = model.PRODUCTCATEGORY;
                item.PRODUCTPRICE = model.PRODUCTPRICE;
                if(model.PRODUCTIMAGE != null)
                {
                    item.PRODUCTIMAGE = model.PRODUCTIMAGE;
                }
                item.PRODUCTDESC = model.PRODUCTDESC;
                db.SaveChanges();
                return true;
            }catch
            {
                return false;
            }
        }

        public bool DeleteProduct(int id)
        {
            try
            {
                var product = db.PRODUCT.Find(id);
                db.PRODUCT.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
