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
    public class PaymentInformationConfiguration : IEntityTypeConfiguration<PaymentInformation>
    {
        public void Configure(EntityTypeBuilder<PaymentInformation> builder)
        {
            builder
                .HasKey(p => p.PaymentID);

            builder
                .Property(p => p.OrderID)
                .IsRequired();

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
                .Property(p => p.PaymentAmount)
                .IsRequired();

            builder
                .Property(p => p.CardID)
                .IsRequired();
        }
    }
}
