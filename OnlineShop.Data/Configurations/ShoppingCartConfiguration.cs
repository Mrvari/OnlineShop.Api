using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Core.Models;
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
                .HasKey(sc => sc.Id);

            builder
                .Property(sc => sc.Id)
                .UseIdentityColumn();

            builder
                .Property(sc => sc.Status)
                .IsRequired();

            builder
                .HasOne(sc => sc.Customer) // ShoppingCart sınıfında bir Customer olduğunu belirtiyoruz
                .WithOne() // Bir ShoppingCart'ın yalnızca bir Customer'a ait olduğunu belirtiyoruz
                .HasForeignKey<ShoppingCart>(sc => sc.ShoppingCartCustomerId) // ShoppingCart'ta bulunan CustomerID sütununun ForeignKey olduğunu belirtiyoruz
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .ToTable("ShoppingCarts");

        }
    }
}
