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
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("tblEmployees");

            // Primary Key
            builder.HasKey(x => x.Emp_id);

            // Properties Configuration
            builder.Property(x => x.Emp_id)
                   .ValueGeneratedOnAdd(); // Auto-increment

            builder.Property(x => x.Emp_ic)
                   .HasMaxLength(30);

            builder.Property(x => x.Emp_name)
                   .HasMaxLength(100);

            builder.Property(x => x.CorpID)
                   .HasMaxLength(20);

            builder.Property(x => x.Suboffice_fk)
                   .HasMaxLength(20);

            builder.Property(x => x.Dept_fk)
                   .HasMaxLength(20);

            builder.Property(x => x.BenefitID)
                   .HasMaxLength(10);

            builder.Property(x => x.Emp_gender)
                   .HasMaxLength(1);

            builder.Property(x => x.Emp_dob);

            builder.Property(x => x.Emp_race)
                   .HasMaxLength(20);

            builder.Property(x => x.Emp_nationality)
                   .HasMaxLength(50);

            builder.Property(x => x.Addr1)
                   .HasMaxLength(150);

            builder.Property(x => x.Addr2)
                   .HasMaxLength(150);

            builder.Property(x => x.Addr3)
                   .HasMaxLength(150);

            builder.Property(x => x.Postcode)
                   .HasMaxLength(10);

            builder.Property(x => x.City)
                   .HasMaxLength(100);

            builder.Property(x => x.State)
                   .HasMaxLength(50);

            builder.Property(x => x.Country)
                   .HasMaxLength(100);

            builder.Property(x => x.Email)
                   .HasMaxLength(100);

            builder.Property(x => x.Cont_no)
                   .HasMaxLength(30);

            builder.Property(x => x.Designation)
                   .HasMaxLength(100);

            builder.Property(x => x.Remarks)
                   .HasMaxLength(100);

            builder.Property(x => x.Join_dt);

            builder.Property(x => x.Ent_dt);

            builder.Property(x => x.BankID)
                   .HasMaxLength(100);

            builder.Property(x => x.BankAccNo)
                   .HasMaxLength(30);

            builder.Property(x => x.Resign_dt);

            builder.Property(x => x.ClientNumber)
                   .HasMaxLength(50);

            builder.Property(x => x.CostCentre)
                   .HasMaxLength(100);

            builder.Property(x => x.IsActive);

            builder.Property(x => x.CreatedDate);

            builder.Property(x => x.LastModifiedBy)
                   .HasMaxLength(20);

            builder.Property(x => x.LastModifiedDate);
        }
    }
}
