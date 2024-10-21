using MudahMed.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.ViewModel.Corporate
{
    public class CorpUserViewModel
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

        // Corporation properties from Corp table
        public int CorpID { get; set; } // Primary key for the corporation
        public string? CorpName { get; set; } // Corporate name
        public string? CorpAddr1 { get; set; } // Address line 1
        public string? CorpAddr2 { get; set; } // Address line 2
        public string? CorpAddr3 { get; set; } // Address line 3
        public string? Postcode { get; set; } // Postal code
        public string? City { get; set; } // City
        public string? State { get; set; } // State
        public string? Country { get; set; } // Country
        public string? ContactPerson { get; set; } // Contact person for the corporation
        public string? CorpContactNo { get; set; } // Contact number for the corporation
        public string? CorpFax { get; set; } // Fax number for the corporation
        public string? CorpRegNo { get; set; } // Registration number of the corporation
        public string? CorpTIN { get; set; } // Tax Identification Number of the corporation
        public int BankID { get; set; } // Bank ID related to the corporation
        public string? BankAccNo { get; set; } // Bank account number for the corporation
        public int? CorpGroupID { get; set; } // Group ID for the corporation
        public string? CorpEmail { get; set; } // Email address of the corporation
        public string? FinanceEmail { get; set; } // Finance-related email address
        public bool IsSuspend { get; set; } // Indicates if the corporation is suspended
        public int? IndustryField { get; set; } // Industry field for the corporation
        public DateTime? CorpCreatedDate { get; set; } // Corporation creation date
        public string? LastModifiedBy { get; set; } // User who last modified the corporation details
        public DateTime? LastModifiedDate { get; set; } // Last modified date of the corporation

        // Navigation property for users
        public virtual ICollection<AppUser> Users { get; set; } = new List<AppUser>();
    }


}
