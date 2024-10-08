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

            // Primary key
            builder.HasKey(x => x.CorpGroupID);

            // Property configurations
            builder.Property(x => x.CorpGroupID)
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Addr1)
                .HasMaxLength(150)
                .IsRequired(false);

            builder.Property(x => x.Addr2)
                .HasMaxLength(150)
                .IsRequired(false);

            builder.Property(x => x.Addr3)
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

            builder.Property(x => x.ContactNo)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(x => x.Fax)
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(x => x.RegNo)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(x => x.TIN)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(x => x.BankID)
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(x => x.BankAccNo)
                .HasMaxLength(30)
                .IsRequired(false);

            builder.Property(x => x.Email)
                .HasMaxLength(500)
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
