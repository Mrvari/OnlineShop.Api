using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models;
using OnlineShop.Data.Configurations;

namespace OnlineShop.Data
{
    public class OnlineShopDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<AddressInformation> AddressInformations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentInformation> PaymentInformations { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<ReturnedProduct> ReturnedProducts { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Product> Products { get; set; }

        public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options) 
            : base(options)
        { }   

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
                .ApplyConfiguration(new PaymentInformationConfiguration());

            builder
                .ApplyConfiguration(new ProductConfiguration());

            builder
                .ApplyConfiguration(new ReturnedProductConfiguration());

            builder
                .ApplyConfiguration(new  ShoppingCartConfiguration());

            builder 
                .ApplyConfiguration(new StockConfiguration());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MusicMarket;Trusted_Connection=True;MultipleActiveResultSets=true", builder =>
                    builder.MigrationsAssembly("OnlineShop.Api")); // Bu satır migrations assembly'sini belirtir
            }
        }

    }
}
