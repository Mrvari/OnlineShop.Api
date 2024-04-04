using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasKey(o => o.Id);

            builder
                .Property(o => o.Id)
                .UseIdentityColumn();

            builder
               .Property(o => o.OrderDate)
               .IsRequired();

            builder
                .Property(o => o.OrderStatus)
                .IsRequired();

            builder
                .Property(o => o.TrackingNumber)
                .IsRequired();

            builder
                .HasOne(o => o.Customer)
                .WithOne()
                .HasForeignKey<Order>(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(o => o.ShoppingCart)
                .WithOne()
                .HasForeignKey<Order>(o => o.CartId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .ToTable("Orders");

           
        }
    }
}
