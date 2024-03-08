using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Core.Models.OrderManagement;
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
            .HasKey(o => o.OrderID);

            builder
                .Property(o => o.CustomerID)
                .IsRequired();

            builder
                .Property(o => o.ShoppingCartID)
                .IsRequired();

            builder
                .Property(o => o.TotalAmount)
                .IsRequired();

            builder
                .Property(o => o.OrderDate)
                .IsRequired();

            builder
                .Property(o => o.OrderStatus)
                .IsRequired();

            builder
                .Property(o => o.deliveryAdress)
                .IsRequired();

            builder
                .Property(o => o.TrackingNumber)
                .IsRequired();

            builder
                .HasOne(o => o.PaymentInformation) // Bir siparişin yalnızca bir ödeme bilgisi olabilir
                .WithOne(p => p.Order) // Tek bir PaymentInformation nesnesi içeren Order'a tek bir Order referansı
                .HasForeignKey<PaymentInformation>(p => p.OrderID);

            builder
                .HasOne(o => o.Return) // Bir siparişin en fazla bir iade işlemi olabilir
                .WithOne(r => r.Order) // Tek bir Return nesnesi içeren Order'a tek bir Order referansı
                .HasForeignKey<Return>(r => r.OrderID) // Return sınıfındaki dış anahtar
                .IsRequired(false);
        }
    }
}
