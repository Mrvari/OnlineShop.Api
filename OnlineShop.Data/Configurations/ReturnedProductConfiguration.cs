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
    public class ReturnedProductConfiguration : IEntityTypeConfiguration<ReturnedProduct>
    {
        public void Configure(EntityTypeBuilder<ReturnedProduct> builder)
        {
            builder
                .HasKey(r => r.Id);

            builder
                .Property(r => r.Id)
                .UseIdentityColumn();

            builder
                .Property(r => r.ReturnReason)
                .IsRequired();

            builder
                .Property(r => r.ReturnDate)
                .IsRequired();

            builder
                .Property(r => r.Contiditon)
                .IsRequired();

            builder
                .Property(r => r.ReturnStatus)
                .IsRequired();

            builder
                .HasOne(r => r.Order)
                .WithOne()
                .HasForeignKey<ReturnedProduct>(r => r.ReturnedOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .ToTable("Returns");
        }
    }
}
