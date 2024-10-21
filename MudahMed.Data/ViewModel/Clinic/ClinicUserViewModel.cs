using MudahMed.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.ViewModel.Clinic
{
    public class ClinicUserViewModel
    {
        // User properties from AppUsers table
        public Guid Id { get; set; } // Unique identifier for the user
        public string? FullName { get; set; } // Full name of the user
        public DateTime? CreatedDate { get; set; } // User creation date
        public Guid? CreatedBy { get; set; } // User who created this entry
        public DateTime? ModifiedDate { get; set; } // User modification date
        public Guid? ModifiedBy { get; set; } // User who modified this entry
        public string? RefTable { get; set; } // Reference table ("tblClinic" or "tblCorp")
        public int? RefId { get; set; } // Reference ID corresponding to the referenced table
        public int? Status { get; set; } // User status (0 = denied, 1 = waiting, 2 = confirmed, etc.)
        public string? UserName { get; set; } // Username for the user
        public string? NormalizedUserName { get; set; } // Normalized username
        public string? Email { get; set; } // Email address of the user
        public string? NormalizedEmail { get; set; } // Normalized email
        public bool EmailConfirmed { get; set; } // Indicates if the email is confirmed
        public string? PasswordHash { get; set; } // Password hash for the user
        public string? SecurityStamp { get; set; } // Security stamp
        public string? ConcurrencyStamp { get; set; } // Concurrency token
        public string? PhoneNumber { get; set; } // Phone number of the user
        public bool PhoneNumberConfirmed { get; set; } // Indicates if the phone number is confirmed
        public bool TwoFactorEnabled { get; set; } // Indicates if two-factor authentication is enabled
        public DateTimeOffset? LockoutEnd { get; set; } // Lockout end date
        public bool LockoutEnabled { get; set; } // Indicates if lockout is enabled
        public int AccessFailedCount { get; set; } // Access failed count for the user

        // Clinic properties from Clinic table
        public int ClinicID { get; set; } // Primary key for the clinic
        public string? ClinicName { get; set; } // Name of the clinic
        public string? ClinicAddr1 { get; set; } // Address line 1
        public string? ClinicAddr2 { get; set; } // Address line 2
        public string? ClinicAddr3 { get; set; } // Address line 3
        public string? Postcode { get; set; } // Postal code
        public string? City { get; set; } // City
        public string? State { get; set; } // State
        public string? Country { get; set; } // Country
        public string? ContactPerson { get; set; } // Contact person at the clinic
        public string? ClinicContactNo { get; set; } // Contact number for the clinic
        public string? ClinicFax { get; set; } // Fax number for the clinic
        public string? ClinicRegNo { get; set; } // Registration number of the clinic
        public string? ClinicTIN { get; set; } // Tax Identification Number of the clinic
        public int? BankID { get; set; } // Bank ID related to the clinic
        public string? BankAccNo { get; set; } // Bank account number for the clinic

        // Additional clinic properties
        public bool IsActive { get; set; } // Indicates if the clinic is active
        public DateTime? RecruitDate { get; set; } // When the clinic was recruited
        public DateTime? RemovedDate { get; set; } // When the clinic was removed
        public string? ClinicGroup { get; set; } // Grouping of clinics

        // Geolocation
        public decimal Latitude { get; set; } // Latitude for the clinic
        public decimal Longitude { get; set; } // Longitude for the clinic

        // Clinic services
        public bool? Is24Hour { get; set; } // Indicates if the clinic operates 24 hours
        public string? RenderedService { get; set; } // Service rendered by the clinic
        public string? PanelType { get; set; } // Type of panel the clinic is part of
        public string? PayeeName { get; set; } // Payee name associated with the clinic

        // Contact details
        public string? Handphone { get; set; } // Handphone number
        public string? ClinicEmail { get; set; } // Email address of the clinic

        // Additional documents and licenses
        public string? ClinicContMMC { get; set; } // MMC contact
        public string? PermanentDoc1 { get; set; } // Permanent document 1
        public string? PermanentDoc1MMC { get; set; } // MMC for permanent document 1
        public string? PermanentDoc2 { get; set; } // Permanent document 2
        public string? PermanentDoc2MMC { get; set; } // MMC for permanent document 2

        // Navigation property for users
        public virtual ICollection<AppUser> Users { get; set; } = new List<AppUser>();
    }


}
