using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Function.Client
{
    public class MenuFunction
    {
        OnlineShopDbContext db = new OnlineShopDbContext();
        public List<Menu> ListMenu(int MenuId)
        {
            return db.Menu.Where(a => a.GroupId == MenuId).ToList();
        }
    }
}
