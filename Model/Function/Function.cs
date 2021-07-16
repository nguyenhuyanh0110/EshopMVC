using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Function
{
    public class Function
    {
        OnlineShopDbContext db = new OnlineShopDbContext();

        public string InsertCategory(CATEGORY category)
        {
            db.CATEGORY.Add(category);
            db.SaveChanges();
            return category.CATEGORYNAME;
        }

        public string InsertUser(USERINFO user)
        {
            db.USERINFO.Add(user);
            db.SaveChanges();
            return user.USERNAME;
        }

        public USERINFO GetUserInfo(String UserName)
        {
            return db.USERINFO.SingleOrDefault(a => a.USERNAME == UserName);
        }

        //check if there is an account
        public bool Login(string UserName, string Password)
        {
            var Result = db.USERINFO.Where(a => a.USERNAME.Equals(UserName) && a.PASSWORD.Equals(Password)).ToList();
            if(Result.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
