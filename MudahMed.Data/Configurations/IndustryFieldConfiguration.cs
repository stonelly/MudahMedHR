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
    public class IndustryFieldConfiguration : IEntityTypeConfiguration<IndustryField>
    {
        public void Configure(EntityTypeBuilder<IndustryField> builder)
        {
            builder.ToTable("tblIndustryField");

            // Primary Key
            builder.HasKey(x => x.ItemID);

            // Configure properties
            builder.Property(x => x.ItemID)
                   .ValueGeneratedOnAdd(); // Auto-increment

            builder.Property(x => x.IndustryFieldName)
                   .HasMaxLength(100);
        }
    }
}
