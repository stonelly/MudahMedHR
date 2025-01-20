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
    public class DependentConfiguration : IEntityTypeConfiguration<Dependent>
    {
        public void Configure(EntityTypeBuilder<Dependent> builder)
        {
            builder.ToTable("tblDependents");

            // Primary Key
            builder.HasKey(x => x.Dep_id);

            // Properties Configuration
            builder.Property(x => x.Dep_id)
                   .ValueGeneratedOnAdd(); // Auto-increment

            builder.Property(x => x.Emp_id)
                   .IsRequired();

            builder.Property(x => x.Dep_name)
                   .HasMaxLength(100);

            builder.Property(x => x.Dep_ic)
                   .HasMaxLength(30);

            builder.Property(x => x.BenefitID)
                   .HasMaxLength(10);

            builder.Property(x => x.Relationship)
                   .HasMaxLength(2);

            builder.Property(x => x.Dep_gender)
                   .HasMaxLength(1);

            builder.Property(x => x.Dep_dob);

            builder.Property(x => x.Dep_race)
                   .HasMaxLength(20);

            builder.Property(x => x.Dep_nationality)
                   .HasMaxLength(50);

            builder.Property(x => x.Join_dt);

            builder.Property(x => x.Ent_dt);

            builder.Property(x => x.ClientNumber)
                   .HasMaxLength(50);

            builder.Property(x => x.Remarks)
                   .HasMaxLength(100);

            builder.Property(x => x.IsActive)
                   .HasDefaultValue(true); // Assuming active by default

            builder.Property(x => x.CreatedDate);

            builder.Property(x => x.LastModifiedBy)
                   .HasMaxLength(30);

            builder.Property(x => x.LastModifiedDate);

            builder.Property(x => x.DepResignDT);

            // Foreign Key relationship with Employee
            builder.HasOne(d => d.Employee)
                   .WithMany(e => e.Dependents)
                   .HasForeignKey(d => d.Emp_id)
                   .OnDelete(DeleteBehavior.Cascade); // Optional: configure delete behavior

        }
    }
}
