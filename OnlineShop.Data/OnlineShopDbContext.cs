using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models.CustomerManagement;
using OnlineShop.Core.Models.OrderManagement;
using OnlineShop.Core.Models.ProductManagement;
using OnlineShop.Core.Models.PromotionManagement;
using OnlineShop.Core.Models.StockManagement;
using OnlineShop.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data
{
    public class OnlineShopDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<AddressInformation> AddressInformations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }
        public DbSet<PaymentInformation> PaymentInformations { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Return> Returns { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Promotion> Promotions { get; set; }

        public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new AddressInformationConfiguration());

            builder
                .ApplyConfiguration(new CreditCardConfiguration());

            builder
                .ApplyConfiguration(new CustomerConfiguration());

            builder
                .ApplyConfiguration(new OrderConfiguration());

            builder
                .ApplyConfiguration(new OrderHistoryConfiguration());

            builder 
                .ApplyConfiguration(new PaymentInformationConfiguration());

            builder
                .ApplyConfiguration(new ProductConfiguration());

            builder
                .ApplyConfiguration(new PromotionConfiguration());

            builder
                .ApplyConfiguration(new ReturnConfiguration());

            builder
                .ApplyConfiguration(new  ShoppingCartConfiguration());

            builder 
                .ApplyConfiguration(new StockConfiguration());

        }
    }
}
