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
    public class ClaimConfiguration : IEntityTypeConfiguration<Claim>
    {
        public void Configure(EntityTypeBuilder<Claim> builder)
        {
            builder.ToTable("tblClaim");

            // Primary Key
            builder.HasKey(c => c.ClaimID);

            // Properties Configuration
            builder.Property(c => c.ClaimID)
                   .ValueGeneratedOnAdd(); // Auto-increment

            builder.Property(c => c.ClinicID)
                   .HasMaxLength(20);

            builder.Property(c => c.Emp_id);

            builder.Property(c => c.Dep_id);

            builder.Property(c => c.BenefitID)
                   .HasMaxLength(10);

            builder.Property(c => c.ConsultDate);

            builder.Property(c => c.ConsultFee)
                   .HasColumnType("decimal(18, 2)");

            builder.Property(c => c.MedFee)
                   .HasColumnType("decimal(18, 2)");

            builder.Property(c => c.XrayFee)
                   .HasColumnType("decimal(18, 2)");

            builder.Property(c => c.LabFee)
                   .HasColumnType("decimal(18, 2)");

            builder.Property(c => c.InjectFee)
                   .HasColumnType("decimal(18, 2)");

            builder.Property(c => c.SurgFee)
                   .HasColumnType("decimal(18, 2)");

            builder.Property(c => c.ScreenFee)
                   .HasColumnType("decimal(18, 2)");

            builder.Property(c => c.DressFee)
                   .HasColumnType("decimal(18, 2)");

            builder.Property(c => c.OthersFee)
                   .HasColumnType("decimal(18, 2)");

            builder.Property(c => c.ReferFee)
                   .HasColumnType("decimal(18, 2)");

            builder.Property(c => c.ReferTo)
                   .HasMaxLength(100);

            builder.Property(c => c.OtherCostRmks)
                   .HasMaxLength(200);

            builder.Property(c => c.TotalCharge)
                   .HasColumnType("decimal(18, 2)");

            builder.Property(c => c.CompanyPay)
                   .HasColumnType("decimal(18, 2)");

            builder.Property(c => c.EmpPay)
                   .HasColumnType("decimal(18, 2)");

            builder.Property(c => c.MCType)
                   .HasMaxLength(10);

            builder.Property(c => c.MCDayGiven)
                   .HasColumnType("decimal(10, 1)");

            builder.Property(c => c.MCStartDate);

            builder.Property(c => c.MCRemarks)
                   .HasMaxLength(100);

            builder.Property(c => c.ClaimStatus)
                   .HasMaxLength(20);

            builder.Property(c => c.DRName)
                   .HasMaxLength(100);

            builder.Property(c => c.MarkupAmt)
                   .HasColumnType("decimal(18, 2)");

            builder.Property(c => c.InvoiceID)
                   .HasMaxLength(20);

            builder.Property(c => c.BillDate);

            builder.Property(c => c.AuditRemarks)
                   .HasMaxLength(400);

            builder.Property(c => c.IsAudit);

            builder.Property(c => c.CreatedDate);

            builder.Property(c => c.LastModifiedBy)
                   .HasMaxLength(50);

            builder.Property(c => c.LastModifiedDate);

           
        }
    }

}
