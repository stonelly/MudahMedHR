using MudahMed.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudahMed.Common.Constants;

namespace MudahMed.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //For Admin role
            var adminRoleId = new Guid("9f685d0f-bd6f-44dd-ab60-c606952eb2a8");
            var corporateRoleId = new Guid("4e233be7-c199-4567-9c07-9271a9de4c64");
            var clinicRoleId = new Guid("376c1d1e-0b04-47da-9657-a2a87faf0a59");
            var employeeRoleId = new Guid("b448a7dc-54c6-4060-90f0-86965c07e8f0");

            //For Admin default account
            var adminId = new Guid("769f41bd-ccd4-45ba-abbd-550ccd0b62e3");
            var corporateId = new Guid("31986efe-9171-44e7-8503-1b4c8f9c1d1b");
            var clinicId = new Guid("faed90a2-9f7d-411a-8119-0fa3a668e660");

            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = adminRoleId,
                Name = Role.Role_Administrator,
                NormalizedName = Role.Role_Administrator.ToUpper(),
                Description = "Administrator role"
            },
            new AppRole
            {
                Id = corporateRoleId,
                Name = Role.Role_Corporate,
                NormalizedName = Role.Role_Corporate.ToUpper(),
                Description = "Corporate HR"
            },
            new AppRole
            {
                Id = clinicRoleId,
                Name = Role.Role_Clinic,
                NormalizedName = Role.Role_Clinic.ToUpper(),
                Description = "Clinic User"
            },
            new AppRole
            {
                Id = employeeRoleId,
                Name = Role.Role_Employee,
                NormalizedName = Role.Role_Employee.ToUpper(),
                Description = "Employee User"
            });

            var hasher = new PasswordHasher<AppUser>();


            modelBuilder.Entity<IndustryField>().HasData(new IndustryField
            {   
                ItemID = 1,
                IndustryFieldName = "TPA"
            });
            modelBuilder.Entity<IndustryField>().HasData(new IndustryField
            {
                ItemID = 2,
                IndustryFieldName = "Corporate"
            });
            modelBuilder.Entity<IndustryField>().HasData(new IndustryField
            {
                ItemID = 3,
                IndustryFieldName = "HealthCare"
            });

            modelBuilder.Entity<Bank>().HasData(new Bank
            {
                Bank_id = 1,
                Bank_name = "Malayan Banking Berhad",
                IsDisplay = true
            });

            modelBuilder.Entity<CorpGroup>().HasData(new CorpGroup
            {
                CorpGroupID = 1,
                Name = "MudahMed Group",
                BankID = 1,
                createdDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
            });


            modelBuilder.Entity<Corp>().HasData(new Corp
            {
                CorpID = 1,
                CorpGroupID = 1,
                Corp_name = "MudahMed Sdb Bhd",
                BankID = 1,
                IsSuspend = false,
                IndustryField = 1,
                createdDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            });

            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abc123!@#"),
                SecurityStamp = string.Empty,
                FullName = "System Adminitrator",
                RefTable = AppUserRefference.tblCorp,
                RefId = 1,
                CreatedDate = DateTime.Now,
                Status = -1 //admin status
            });

            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = corporateId,
                UserName = "corporate@gmail.com",
                NormalizedUserName = "corporate@GMAIL.COM",
                Email = "corporate@gmail.com",
                NormalizedEmail = "corporate@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abcd!234"),
                SecurityStamp = string.Empty,
                FullName = "HR Adminitrator",
                RefTable = AppUserRefference.tblCorp,
                RefId = 1,
                Status = 0 //corporate status
            });

            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                ClinicID = 1,
                Clinic_name = "Clinic Test 1"
            });

            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = clinicId,
                UserName = "clinic@gmail.com",
                NormalizedUserName = "clinic@GMAIL.COM",
                Email = "clinic@gmail.com",
                NormalizedEmail = "clinic@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abcd!234"),
                SecurityStamp = string.Empty,
                FullName = "Clinic Adminitrator",
                RefTable = AppUserRefference.tblClinic,
                RefId = 1,
                Status = 0 //clinic status
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = adminRoleId,
                UserId = adminId
            });
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = corporateRoleId,
                UserId = corporateId
            });
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = clinicRoleId,
                UserId = clinicId
            });
        }
    }
}