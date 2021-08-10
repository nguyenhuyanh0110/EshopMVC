using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Function.Client
{
     public class ContactFunction
    {
        OnlineShopDbContext db = new OnlineShopDbContext();

        public Contact GetActiveContact()
        {
            return db.Contact.SingleOrDefault(a => a.Status == true);
        }

        public int FeedBack(Feedback fb)
        {
            db.Feedback.Add(fb);
            db.SaveChanges();
            return fb.Id;
        }
    }
}
