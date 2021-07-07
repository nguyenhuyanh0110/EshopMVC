using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class  UserModel
    {

        //create a variable of Dbcontext
        private OnlineShopDbContext context = null;
        
        //create constructure for UserModel using variable context
        public UserModel()
        {
            context = new OnlineShopDbContext();
        }

        //create method Login using variable context 
        public bool Login(string UserName, string Password)
        {
            //using mapping for connect to attribute DB
            object[] sqlvariable = {
                new SqlParameter("@UserName", UserName),
                new SqlParameter("@Password", Password)
            };
            //create a variable to take SQL result, cause the method is true and false so SQLQuery has boolean type
            var result = context.Database.SqlQuery<bool>("Account_Login @UserName, @Password", sqlvariable).SingleOrDefault();
            return result;
        }
    }
}
