using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace OnlineShop.Data.Configurations
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder
                .HasKey(s => s.Id); //PK

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
                .WithOne()
                .HasForeignKey<Stock>(s => s.StockProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .ToTable("Stocks");
        }
    }
}
