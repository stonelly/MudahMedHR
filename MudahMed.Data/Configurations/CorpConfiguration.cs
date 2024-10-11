using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MudahMed.Data.Entities;

namespace MudahMed.Data.Configurations
{
    public class CorpConfiguration : IEntityTypeConfiguration<Corp>
    {
        public void Configure(EntityTypeBuilder<Corp> builder)
        {
            builder.ToTable("tblCorp");

            // Primary Key
            builder.HasKey(x => x.CorpID);

            // Configure properties
            builder.Property(x => x.CorpID)
                   .ValueGeneratedOnAdd(); // Auto-increment

            builder.Property(x => x.Corp_name)
                   .HasMaxLength(4000);

            builder.Property(x => x.Corp_addr1)
                   .HasMaxLength(150);

            builder.Property(x => x.Corp_addr2)
                   .HasMaxLength(150);

            builder.Property(x => x.Corp_addr3)
                   .HasMaxLength(150);

            builder.Property(x => x.postcode)
                   .HasMaxLength(10);

            builder.Property(x => x.city)
                   .HasMaxLength(100);

            builder.Property(x => x.state)
                   .HasMaxLength(50);

            builder.Property(x => x.country)
                   .HasMaxLength(100);

            builder.Property(x => x.ContactPerson)
                   .HasMaxLength(100);

            builder.Property(x => x.Corp_ContactNo)
                   .HasMaxLength(50);

            builder.Property(x => x.Corp_fax)
                   .HasMaxLength(20);

            builder.Property(x => x.Corp_RegNo)
                   .HasMaxLength(50);

            builder.Property(x => x.Corp_TIN)
                   .HasMaxLength(50);

            builder.Property(x => x.BankID)
                   .IsRequired();

            builder.Property(x => x.BankAccNo)
                   .HasMaxLength(30);

            builder.Property(x => x.CorpGroupID)
                   .IsRequired(false);

            builder.Property(x => x.Email)
                   .HasMaxLength(400);

            builder.Property(x => x.FinanceEmail)
                   .HasMaxLength(200);

            builder.Property(x => x.IsSuspend)
                   .IsRequired();

            builder.Property(x => x.IndustryField)
                   .IsRequired(false);

            builder.Property(x => x.createdDate)
                   .IsRequired(false);

            builder.Property(x => x.LastModifiedBy)
                   .HasMaxLength(200);

            builder.Property(x => x.LastModifiedDate)
                   .IsRequired(false);

            // Foreign Key relationship with CorpGroup
            builder.HasOne(d => d.CorpGroup)
                   .WithMany(e => e.Corporations)
                   .HasForeignKey(d => d.CorpGroupID)
                   .OnDelete(DeleteBehavior.Cascade); // Optional: configure delete behavior

        }
    }
}
