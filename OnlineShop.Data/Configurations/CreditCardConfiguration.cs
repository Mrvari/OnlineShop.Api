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
    public class CreditCardConfiguration :IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder
                .HasKey(cd => cd.Id); // primary key 

            builder
                .Property(cd => cd.Id)
                .UseIdentityColumn();

            builder
                .Property(cd => cd.CardHolderName)
                .IsRequired();

            builder
                .Property(cd => cd.cardNumber)
                .IsRequired();

            builder
                .Property(cd => cd.expiryDate)
                .IsRequired();

            builder
                .Property(cd => cd.cvv)
                .IsRequired();

            builder
                .HasOne(cd => cd.Customer)
                .WithMany(c => c.CreditCards)
                .HasForeignKey(cd => cd.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .ToTable("CreditCards");
        }
    }
}
