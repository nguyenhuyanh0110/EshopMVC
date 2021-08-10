using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Database.Entity
{
    public partial class OnlineShopDbContext : DbContext
    {
        public OnlineShopDbContext()
            : base("name=OnlineShopDbContext")
        {
        }

        public virtual DbSet<CATEGORY> CATEGORY { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuType> MenuType { get; set; }
        public virtual DbSet<PRODUCT> PRODUCT { get; set; }
        public virtual DbSet<USERINFO> USERINFO { get; set; }
        public virtual DbSet<CategoryMenu> CategoryMenu { get; set; }
        public virtual DbSet<Slide> Slide { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>()
                .Property(e => e.MenuStatus)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.PRODUCTIMAGE)
                .IsUnicode(false);

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

            modelBuilder.Entity<Order>()
                .Property(e => e.ShipMobile)
                .IsUnicode(false);
            modelBuilder.Entity<Feedback>()
                .Property(e => e.Phone)
                .IsUnicode(false);
            modelBuilder.Entity<Feedback>()
                .Property(e => e.Email)
                .IsUnicode(false);
        }
    }
}
