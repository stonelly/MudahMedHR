﻿using MudahMed.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MudahMed.Data.Configurations
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.ToTable("Jobs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Popular).HasDefaultValue(0);
            builder.Property(x => x.Slug).IsRequired();
        }
    }
}