using MudahMed.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.ViewModel.Corporate
{
    public class CorpViewModel
    {        

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
