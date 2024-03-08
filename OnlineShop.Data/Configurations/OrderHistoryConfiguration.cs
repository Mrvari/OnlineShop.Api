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
    public class OrderHistoryConfiguration : IEntityTypeConfiguration<OrderHistory>
    {
        public void Configure(EntityTypeBuilder<OrderHistory> builder)
        {
            builder
                .HasKey(oh => oh.HistoryID);

            builder
                .Property(oh => oh.CustomerID)
                .IsRequired();

            builder
                .Property(oh => oh.OrderID)
                .IsRequired();

            builder
                .Property(oh => oh.OrderDate)
                .IsRequired();
        }
    }
}
