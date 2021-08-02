using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Function.Client
{
    public class SlideFunction
    {
        OnlineShopDbContext db = new OnlineShopDbContext();

        public List<Slide> ListSlide()
        {
            return db.Slide.Where(a => a.Status == true).ToList();
        }
    }
}
