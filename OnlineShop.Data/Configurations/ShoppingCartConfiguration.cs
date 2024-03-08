using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Core.Models.CustomerManagement;
using OnlineShop.Core.Models.OrderManagement;
using OnlineShop.Core.Models.ProductManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Configurations
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder
                .HasKey(sc => sc.CartID);

            builder
                .Property(sc => sc.CustomerID)
            .IsRequired();

            builder
                .Property(sc => sc.ProducrID)
                .IsRequired();

            builder
                .Property(sc => sc.Status)
                .IsRequired();

            builder
                .Property(sc => sc.PaymentStatus)
                .IsRequired();

            builder
                .Property(sc => sc.Cuponcode)
                .IsRequired();

            builder
                .Property(sc => sc.TotalAmount)
                .IsRequired();

            builder
                .Property(sc => sc.ItemCount)
                .IsRequired();

            builder
                .Property(sc => sc.DiscountAmount)
                .IsRequired();

            //builder
            //    .HasMany(sc => sc.Products) // Bir alışveriş sepetinin birden fazla ürünü olabilir
            //    .WithOne(e=>e.ShoppingCart) // Tek taraflı ilişki olduğu için WithOne çağrısında parametre belirtilmez
            //    .HasForeignKey<Product>((p => p.);


            builder
                .HasMany(e => e.Products)
                .WithOne(e => e.ShoppingCart)
                .HasForeignKey(e => e.ShoppingCartID);

            builder
                .HasOne(sc => sc.Order) // Bir alışveriş sepetinin yalnızca bir siparişi olabilir
                .WithOne(e=> e.ShoppingCart) // Tek taraflı ilişki olduğu için parametre belirtilmez
                .HasForeignKey<Order>(o => o.ShoppingCartID)
                .OnDelete( DeleteBehavior.Restrict); // Order sınıfındaki dış anahtar

            builder
                .HasOne(e => e.Customer)
                .WithOne(e => e.ShoppingCart)
                .HasForeignKey<Customer>(e => e.CustomerID);
        }
    }
}
