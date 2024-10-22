using MudahMed.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.ViewModel.Clinic
{
    public class ClinicUserViewModel : ClinicViewModel
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
        
    }


}
