using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Model.Entity
{
    public partial class OnlineShopDbContext : DbContext
    {
        public OnlineShopDbContext()
            : base("name=OnlineShopDbContext")
        {
        }

        public virtual DbSet<CATEGORY> CATEGORY { get; set; }
        public virtual DbSet<PRODUCT> PRODUCT { get; set; }
        public virtual DbSet<USERINFO> USERINFO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<USERINFO>()
                .Property(e => e.SODT)
                .IsUnicode(false);

            modelBuilder.Entity<USERINFO>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<USERINFO>()
                .Property(e => e.USERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<USERINFO>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);
        }
    }
}
