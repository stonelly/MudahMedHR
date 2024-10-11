using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using MudahMed.Data.Entities;

namespace MudahMed.Data.Configurations
{
    public class CorpGroupConfiguration : IEntityTypeConfiguration<CorpGroup>
    {
        public void Configure(EntityTypeBuilder<CorpGroup> builder)
        {
            builder.ToTable("tblCorpGroup");

            // Primary Key
            builder.HasKey(x => x.CorpGroupID);

            // Configure properties
            builder.Property(x => x.CorpGroupID)
                   .ValueGeneratedOnAdd(); // Auto-increment

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Addr1)
                   .HasMaxLength(150);

            builder.Property(x => x.Addr2)
                   .HasMaxLength(150);

            builder.Property(x => x.Addr3)
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

            builder.Property(x => x.ContactNo)
                   .HasMaxLength(50);

            builder.Property(x => x.Fax)
                   .HasMaxLength(20);

            builder.Property(x => x.RegNo)
                   .HasMaxLength(50);

            builder.Property(x => x.TIN)
                   .HasMaxLength(50);

            builder.Property(x => x.BankID)
                   .IsRequired();

            builder.Property(x => x.BankAccNo)
                   .HasMaxLength(30);

            builder.Property(x => x.Email)
                   .HasMaxLength(500);

            builder.Property(x => x.createdDate)
                   .IsRequired(false);

            builder.Property(x => x.LastModifiedBy)
                   .HasMaxLength(200);

            builder.Property(x => x.LastModifiedDate)
                   .IsRequired(false);
        }
    }
}
