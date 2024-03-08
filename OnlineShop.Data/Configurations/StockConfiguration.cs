using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models.StockManagement;
using OnlineShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using OnlineShop.Core.Models.ProductManagement;

namespace OnlineShop.Data.Configurations
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder
                .HasKey(s => s.StockID); //PK

            builder
                .Property(s => s.ProductID)
                .IsRequired();

            builder
                .Property(s => s.Quantity)
                .IsRequired();

            builder
                .Property(s => s.InTransitQuantity)
                .IsRequired();

            builder
                .Property(s => s.LastUpdate)
                .IsRequired();

            builder
                .HasOne(s => s.Product)
                .WithOne(p => p.Stock)
                .HasForeignKey<Product>(p => p.StockID)
                .IsRequired();
        }
    }
}
