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
    public class DiagnosisConfiguration : IEntityTypeConfiguration<Diagnosis>
    {
        public void Configure(EntityTypeBuilder<Diagnosis> builder)
        {
            builder.ToTable("tblDiagnosis");

            // Primary Key
            builder.HasKey(x => x.Diag_id);

            // Properties Configuration
            builder.Property(x => x.Diag_id)
                   .IsRequired();

            builder.Property(x => x.Diag_cat)
                   .HasMaxLength(10);

            builder.Property(x => x.Diag_desc)
                   .HasMaxLength(200);

            builder.Property(x => x.IsRemarksReq)
                   .IsRequired();

            builder.Property(x => x.IsActive)
                   .IsRequired();

            builder.Property(x => x.IsLTM)
                   .IsRequired();

            builder.Property(x => x.IsGP);

            builder.Property(x => x.DiagGrp)
                   .HasMaxLength(200);
        }
    }
}
