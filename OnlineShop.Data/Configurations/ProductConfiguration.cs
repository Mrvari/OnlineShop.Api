using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Core.Models.ProductManagement;
using OnlineShop.Core.Models.PromotionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(p => p.ProductID);

            builder
                .Property(p => p.ProductName)
                .IsRequired()
                .HasMaxLength(20);

            builder
                .Property(p => p.CategoryID)
                .IsRequired();

            builder
                .Property(p => p.ShoppingCartID)
                .IsRequired();

            builder
                .Property(p => p.Price)
                .IsRequired();

            builder
                .Property(p => p.Description)
                .HasMaxLength(200);

            builder
                .Property(p => p.Images)
                .IsRequired();

            builder
                .Property(p => p.Brand)
                .IsRequired();

            builder
                .Property(p => p.TechnicalSpecifications)
                .HasMaxLength(200);

            builder
                .Property(p => p.Reviews)
                .HasMaxLength(200);

            builder
                .Property(p => p.ReviewScores)
                .IsRequired()
                .HasPrecision(3, 2);

            builder.HasOne(p => p.Stock)
               .WithOne(s => s.Product)
               .HasForeignKey<Product>(p => p.StockID)
               .IsRequired();

            builder
                .HasMany(p => p.Promotions) // Bir ürünün birden fazla promosyonu olabilir
                .WithMany(pr => pr.Products) // Bir promosyonun birden fazla ürünü olabilir
                .UsingEntity<Dictionary<string, object>>(
                    "ProductPromotion",
                    j => j
                        .HasOne<Promotion>()
                        .WithMany()
                        .HasForeignKey("PromotionId"),
                    j => j
                        .HasOne<Product>()
                        .WithMany()
                        .HasForeignKey("ProductId"),
                    j =>
                    {
                        j.HasKey("ProductId", "PromotionId");
                        j.ToTable("ProductPromotion");
                    });
        }
    }
}
