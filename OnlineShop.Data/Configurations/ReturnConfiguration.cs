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
    public class ReturnConfiguration : IEntityTypeConfiguration<Return>
    {
        public void Configure(EntityTypeBuilder<Return> builder)
        {
            builder
                .HasKey(r => r.ReturnID);

            builder
                .Property(r => r.OrderID)
                .IsRequired();

            builder
                .Property(r => r.ProductID)
                .IsRequired();

            builder
                .Property(r => r.CustomerID)
                .IsRequired();

            builder
                .Property(r => r.ReturnReason)
                .IsRequired();

            builder
                .Property(r => r.ReturnDate)
                .IsRequired();

            builder
                .Property(r => r.QuantityReturned)
                .IsRequired();

            builder
                .Property(r => r.Condution)
                .IsRequired();

            builder
                .Property(r => r.RefaundAmount)
                .IsRequired();

            builder
                .Property(r => r.ReturnStatus)
                .IsRequired();
        }
    }
}
