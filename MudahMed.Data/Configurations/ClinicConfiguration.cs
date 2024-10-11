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
    public class ClinicConfiguration : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.ToTable("tblClinic");

            // Primary Key
            builder.HasKey(x => x.ClinicID);

            // Configure properties
            builder.Property(x => x.ClinicID)
                   .ValueGeneratedOnAdd(); // Auto-increment

            builder.Property(x => x.Clinic_name)
                   .HasMaxLength(100);

            builder.Property(x => x.Clinic_addr1)
                   .HasMaxLength(150);

            builder.Property(x => x.Clinic_addr2)
                   .HasMaxLength(150);

            builder.Property(x => x.Clinic_addr3)
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
                   .IsRequired(false);

            builder.Property(x => x.BankAccNo)
                   .HasMaxLength(30);

            builder.Property(x => x.rendered_svc)
                   .HasMaxLength(10);

            builder.Property(x => x.panel_type)
                   .HasMaxLength(10);

            builder.Property(x => x.PayeeName)
                   .HasMaxLength(100);

            builder.Property(x => x.Handphone)
                   .HasMaxLength(20);

            builder.Property(x => x.Email)
                   .HasMaxLength(200);

            builder.Property(x => x.IsActive)
                   .IsRequired();

            builder.Property(x => x.RecruitDate)
                   .IsRequired(false);

            builder.Property(x => x.RemovedDate)
                   .IsRequired(false);

            builder.Property(x => x.LastModifiedBy)
                   .HasMaxLength(100);

            builder.Property(x => x.LastModifiedDate)
                   .IsRequired(false);

            builder.Property(x => x.ClinicGroup)
                   .HasMaxLength(100);

            builder.Property(x => x.Latitude)
                   .IsRequired();

            builder.Property(x => x.Longitude)
                   .IsRequired();

            builder.Property(x => x.Is24Hour)
                   .IsRequired(false);

            // Other properties can be configured similarly...
        }
    }
}
