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
    public class AddressInformationConfiguration : IEntityTypeConfiguration<AddressInformation>
    {
        public void Configure(EntityTypeBuilder<AddressInformation> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(a => a.Id)
                .UseIdentityColumn();

            builder
                .Property(a => a.County)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(a => a.street)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(a => a.zipcode)
               .IsRequired();

            builder
                .HasOne(a => a.Customer)
                .WithMany(c => c.AddressInformations)
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .ToTable("AddressInformations");
            
        }
    }
}
