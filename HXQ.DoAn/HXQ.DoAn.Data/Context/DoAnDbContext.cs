using HXQ.DoAn.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXQ.DoAn.Data.Context
{
    public class DoAnDbContext : IdentityDbContext<Account, Role, long>
    {
        public DoAnDbContext(DbContextOptions<DoAnDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<AccountDetail> AccountDetails { get; set; }
        public DbSet<AttributeProduct> AttributeProducts { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Các cấu hình Fluent API bổ sung nếu cần
        }
    }
}
