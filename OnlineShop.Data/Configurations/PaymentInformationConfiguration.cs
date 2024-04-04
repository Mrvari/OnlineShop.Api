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
    public class PaymentInformationConfiguration : IEntityTypeConfiguration<PaymentInformation>
    {
        public void Configure(EntityTypeBuilder<PaymentInformation> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.PaymentDate)
                .IsRequired();

            builder
                .Property(p => p.PaymentType)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(p => p.PaymentStatus)
                .IsRequired();

            builder
                .HasOne(p => p.Order)
                .WithOne()
                .HasForeignKey<PaymentInformation>(p => p.PaymentInformationOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .ToTable("Payments");
        }
    }
}
