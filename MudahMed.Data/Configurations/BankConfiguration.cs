using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MudahMed.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Configurations
{
    public class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.ToTable("tblBanks");

            // Primary Key
            builder.HasKey(x => x.Bank_id);

            // Configure properties
            builder.Property(x => x.Bank_id)
                   .ValueGeneratedOnAdd(); // Auto-increment

            builder.Property(x => x.Bank_name)
                   .HasMaxLength(100);

            builder.Property(x => x.IsDisplay)
                   .IsRequired(); // Required field
        }
    }
}
