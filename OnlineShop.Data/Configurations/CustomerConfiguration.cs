using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Core.Models;
using System;
using System.Text;


namespace OnlineShop.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(cd => cd.Id)
                .UseIdentityColumn();

            builder
                .Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(256);

            builder
                .Property(c => c.Password)
                .IsRequired()
                .HasMaxLength(64);

            builder
                .Property(c => c.Phone)
                .IsRequired();

            builder
                .ToTable("Customers");
        }

    }
}
