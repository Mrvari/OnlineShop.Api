using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Core.Models;


namespace OnlineShop.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(pr => pr.Id);

            builder
                .Property(pr => pr.Id)
                .UseIdentityColumn();

            builder
                .Property(pr => pr.ProductName)
                .IsRequired()
                .HasMaxLength(20);

            builder
                .Property(pr => pr.CategoryId)
                .IsRequired();

            builder
               .Property(pr => pr.Price)
               .IsRequired();

            builder
                .Property(pr => pr.Description)
                .HasMaxLength(200);

            builder
                .Property(pr => pr.Images)
                .IsRequired();

            builder
                .Property(pr => pr.Brand)
                .IsRequired();

            builder
                .Property(pr => pr.TechnicalSpecifications)
                .HasMaxLength(200);

            builder
                .Property(pr => pr.Reviews)
                .HasMaxLength(200);

            builder
                .Property(pr => pr.ReviewScores)
                .IsRequired()
                .HasPrecision(3, 2);

            builder
                .HasOne(pr => pr.ShoppingCart)
                .WithMany(sc => sc.Products)
                .HasForeignKey(pr => pr.CartId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .ToTable("Products");
        }
    }
}
