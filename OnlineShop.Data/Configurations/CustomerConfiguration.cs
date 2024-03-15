using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Core.Models.CustomerManagement;
using OnlineShop.Core.Models.OrderManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(c => c.CustomerID);

            builder
                .Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(256);

            builder
                .Property(c => c.Password)
                .IsRequired()
                .HasMaxLength(64);

            builder
                .Property(c => c.Phone)
                .IsRequired();

            //builder
            //     .HasOne(c => c.ShoppingCart) // Bir müşterinin yalnızca bir alışveriş sepeti olabilir
            //     .WithOne() // Tek taraflı ilişki olduğu için parametre belirtilmez
            //     .HasForeignKey<ShoppingCart>(sc => sc.CustomerID)
            //     .OnDelete(DeleteBehavior.Restrict);


            builder
                .HasMany(c => c.AddressInformations) // Bir müşterinin birden fazla adres bilgisi olabilir
                .WithOne(a => a.Customer) // Birden fazla AddressInformation nesnesi içeren Customer'a tek bir Customer referansı
                .HasForeignKey(a => a.CustomerID);

            builder
                .HasMany(c => c.CreditCards) // Bir müşterinin birden fazla kredi kartı olabilir
                .WithOne(cd => cd.Customer) // Birden fazla CreditCard nesnesi içeren Customer'a tek bir Customer referansı
                .HasForeignKey(cd => cd.CustomerID);

            builder
                .HasOne(c => c.OrderHistory) // Bir müşterinin yalnızca bir sipariş geçmişi olabilir
                .WithOne(oh => oh.Customer) // Tek bir OrderHistory nesnesi içeren Customer'a tek bir Customer referansı
                .HasForeignKey<OrderHistory>(oh => oh.CustomerID);
            builder
                .HasMany(c => c.Orders) // Bir müşterinin birden fazla siparişi olabilir
                .WithOne(o => o.Customer) // Birden fazla Order nesnesi içeren Customer'a tek bir Customer referansı
                .HasForeignKey(o => o.CustomerID);
        }
    }
}
