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

            // Primary key
            builder.HasKey(x => x.CorpID);

            // Property configurations
            builder.Property(x => x.CorpID)
                .UseIdentityColumn();

            builder.Property(x => x.CorpName)
                .HasMaxLength(4000)
                .IsRequired(false); // Change to true if required

            builder.Property(x => x.CorpAddr1)
                .HasMaxLength(150)
                .IsRequired(false);

            builder.Property(x => x.CorpAddr2)
                .HasMaxLength(150)
                .IsRequired(false);

            builder.Property(x => x.CorpAddr3)
                .HasMaxLength(150)
                .IsRequired(false);

            builder.Property(x => x.Postcode)
                .HasMaxLength(10)
                .IsRequired(false);

            builder.Property(x => x.City)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.State)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(x => x.Country)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.ContactPerson)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.CorpContactNo)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(x => x.CorpFax)
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(x => x.CorpRegNo)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(x => x.CorpTIN)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(x => x.BankID)
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(x => x.BankAccNo)
                .HasMaxLength(30)
                .IsRequired(false);

            builder.Property(x => x.Email)
                .HasMaxLength(400)
                .IsRequired(false);

            builder.Property(x => x.FinanceEmail)
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(x => x.IsSuspend)
                .IsRequired();

            builder.Property(x => x.IndustryField)
                .IsRequired(false);

            builder.Property(x => x.CreatedDate)
                .IsRequired(false);

            builder.Property(x => x.LastModifiedBy)
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(x => x.LastModifiedDate)
                .IsRequired(false);

        }
    }
}
