using Database.Entity;
using System;
using System.Linq;

namespace Model.Function.Client
{
    public class UserClientFunction
    {
        OnlineShopDbContext db = new OnlineShopDbContext();

        public long InsertUser(USERINFO user)
        {
            db.USERINFO.Add(user);
            db.SaveChanges();
            return user.USERID;
        }

        public USERINFO GetUserInfo(String UserName)
        {
            return db.USERINFO.SingleOrDefault(a => a.USERNAME == UserName);
        }

        public bool CheckUserInfo(string UserName)
        {
            var Result = db.USERINFO.Count(a => a.USERNAME.Equals(UserName));
            if (Result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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

        public bool Update (USERINFO user)
        {
            try
            {
                var update = db.USERINFO.Find(user);
                update.USERNAME = user.USERNAME;
                update.HOTEN = user.HOTEN;
                update.SODT = user.SODT;
                update.EMAIL = user.EMAIL;
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
