using MudahMed.Data.Configurations;
using MudahMed.Data.Entities;
using MudahMed.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.DataContext
{
    public partial class DataDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public DataDbContext()
        {
        }

        public DataDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set delete behavior for all foreign keys to Restrict
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
            //Configure using Fluent API
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());

            modelBuilder.ApplyConfiguration(new BankConfiguration());
            modelBuilder.ApplyConfiguration(new ClinicConfiguration());
            modelBuilder.ApplyConfiguration(new CorpConfiguration());
            modelBuilder.ApplyConfiguration(new CorpGroupConfiguration());
            modelBuilder.ApplyConfiguration(new DependentConfiguration());
            modelBuilder.ApplyConfiguration(new DiagnosisConfiguration());
            modelBuilder.ApplyConfiguration(new DrugConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new IndustryFieldConfiguration());

            // Identity configurations
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

            // Configure relationships with Bank
            //modelBuilder.Entity<Clinic>().HasOne(c => c.Bank).WithMany(b => b.Clinics).HasForeignKey(c => c.BankID).OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes if needed
            //modelBuilder.Entity<Corp>().HasOne(c => c.Bank).WithMany(b => b.Corporations).HasForeignKey(c => c.BankID).OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<CorpGroup>().HasOne(cg => cg.Bank).WithMany(b => b.CorpGroups).HasForeignKey(cg => cg.BankID).OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<Employee>().HasOne(e => e.Bank).WithMany(b => b.Employees).HasForeignKey(e => e.BankID).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AppUser>()
             .HasOne(u => u.Corp)
             .WithMany() // Assuming a Corp can have many users
             .HasForeignKey(u => u.RefId)
             .IsRequired(false); // Change to true if RefId is required

            modelBuilder.Entity<AppUser>()
                .HasOne(u => u.Clinic)
                .WithMany() // Assuming a Clinic can have many users
                .HasForeignKey(u => u.RefId)
                .IsRequired(false); // Adjust based on your requirements


            //Data seeding
            modelBuilder.Seed();
        }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Corp> Corps { get; set; }
        public DbSet<CorpGroup> CorpGroups { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
        public DbSet<Diagnosis> Diagnosis { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<IndustryField> IndustryFields { get; set; }
    }
}
