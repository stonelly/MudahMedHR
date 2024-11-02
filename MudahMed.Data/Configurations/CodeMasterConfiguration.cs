using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MudahMed.Data.Entities;

    public class CodeMasterConfiguration : IEntityTypeConfiguration<CodeMaster>
    {
        public void Configure(EntityTypeBuilder<CodeMaster> builder)
        {
            builder.ToTable("tblCodeMaster");

            // Primary Key
            builder.HasKey(x => x.CodeMaster_id);
            builder.Property(x => x.CodeMaster_id)
                   .ValueGeneratedOnAdd(); // Auto-increment

            // Properties Configuration
            builder.Property(x => x.CodeType)
                   .IsRequired()
                   .HasMaxLength(30);

            builder.Property(x => x.CodeValue)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.CodeDescription)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(x => x.Sequence)
                   .IsRequired(false); // Adjust based on whether it's nullable

            builder.Property(x => x.IsActive)
                   .IsRequired();

            builder.Property(x => x.CreatedDateBy)
                   .HasMaxLength(50);

            builder.Property(x => x.CreatedDate)
                   .IsRequired(false); // Adjust based on whether it's nullable

            builder.Property(x => x.LastModifiedBy)
                   .HasMaxLength(50);

            builder.Property(x => x.LastModifiedDate)
                   .IsRequired(false); // Adjust based on whether it's nullable
        }
    }

}
