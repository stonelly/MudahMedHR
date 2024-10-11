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
    public class DrugConfiguration : IEntityTypeConfiguration<Drug>
    {
        public void Configure(EntityTypeBuilder<Drug> builder)
        {
            builder.ToTable("tblDrugs");

            // Primary Key
            builder.HasKey(x => x.DrugID);

            // Properties Configuration
            builder.Property(x => x.DrugID)
                   .IsRequired();

            builder.Property(x => x.DrugType_CodeFK)
                   .IsRequired();

            builder.Property(x => x.DrugCatFFS_CodeFK)
                   .IsRequired();

            builder.Property(x => x.DrugDesc)
                   .HasMaxLength(500)
                   .IsRequired();

            builder.Property(x => x.ATCClass)
                   .HasMaxLength(20);

            builder.Property(x => x.DrugMIMSClass_CodeFK)
                   .IsRequired();

            builder.Property(x => x.GenericName)
                   .HasMaxLength(500);

            builder.Property(x => x.DrugRoute_CodeFK)
                   .IsRequired();

            builder.Property(x => x.DrugUnit_CodeFK)
                   .IsRequired();

            builder.Property(x => x.ICDCode)
                   .HasMaxLength(500);

            builder.Property(x => x.IsActive)
                   .HasDefaultValue(true); // Assuming active by default

            builder.Property(x => x.CreatedDate)
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.CreatedBy)
                   .HasMaxLength(50);

            builder.Property(x => x.ModifyDate)
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.ModifyBy)
                   .HasMaxLength(50);

            builder.Property(x => x.DrugChrgField_CodeFK)
                   .HasMaxLength(20);

            builder.Property(x => x.UnitPrice)
                   .HasColumnType("money");

            builder.Property(x => x.IsChronic);

            builder.Property(x => x.MaxQty);

            builder.Property(x => x.MaxPrice)
                   .HasColumnType("decimal(18, 2)");

            builder.Property(x => x.DrugPoisonFFS_CodeFK)
                   .HasMaxLength(20);

            builder.Property(x => x.CeilingPrice)
                   .HasColumnType("decimal(18, 2)");

            builder.Property(x => x.IsExclusion);
        }
    }
}
