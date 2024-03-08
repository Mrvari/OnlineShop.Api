using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Core.Models.PromotionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Configurations
{
    public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder
                .HasKey(pr => pr.PromotionID);

            builder
                .Property(pr => pr.CustomerID)
                .IsRequired();

            builder
                .Property(pr => pr.ProductID)
                .IsRequired();

            builder
                .Property(pr => pr.Cuponcode)
                .IsRequired()
                .HasMaxLength(20);

            builder
                .Property(pr => pr.DiscountAmount)
                .IsRequired();

            builder
                .Property(pr => pr.ExpireDate)
                .IsRequired();

            
        }
    }
}
