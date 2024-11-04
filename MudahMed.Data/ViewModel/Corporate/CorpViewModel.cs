using MudahMed.Data.Entities;
using MudahMed.Data.ViewModel.Bank;
using MudahMed.Data.ViewModel.CorpGroup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.ViewModel.Corporate
{
    public class CorpViewModel
    {

        [Key]
        public int CorpID { get; set; } // Primary Key

        [Display(Name = "Corporate Name")]
        [StringLength(4000, ErrorMessage = "The corporate name cannot be more than 4000 characters.")]
        [Required(ErrorMessage = "The corporate name is required.")]
        public string? Corp_name { get; set; } // The name of the corporation

        [Display(Name = "Address Line 1")]
        [StringLength(150, ErrorMessage = "The address line 1 cannot be more than 150 characters.")]
        public string? Corp_addr1 { get; set; } // The first line of the corporation's address

        [Display(Name = "Address Line 2")]
        [StringLength(150, ErrorMessage = "The address line 2 cannot be more than 150 characters.")]
        public string? Corp_addr2 { get; set; } // The second line of the corporation's address

        [Display(Name = "Address Line 3")]
        [StringLength(150, ErrorMessage = "The address line 3 cannot be more than 150 characters.")]
        public string? Corp_addr3 { get; set; } // The third line of the corporation's address

        [Display(Name = "Postcode")]
        [StringLength(10, ErrorMessage = "The postcode cannot be more than 10 characters.")]
        public string? postcode { get; set; } // The postcode of the corporation's address

        [Display(Name = "City")]
        [StringLength(100, ErrorMessage = "The city cannot be more than 100 characters.")]
        public string? city { get; set; } // The city of the corporation's address

        [Display(Name = "State")]
        [StringLength(50, ErrorMessage = "The state cannot be more than 50 characters.")]
        public string? state { get; set; } // The state of the corporation's address

        [Display(Name = "Country")]
        [StringLength(100, ErrorMessage = "The country cannot be more than 100 characters.")]
        public string? country { get; set; } // The country of the corporation's address

        [Display(Name = "Contact Person")]
        [StringLength(100, ErrorMessage = "The contact person cannot be more than 100 characters.")]
        public string? ContactPerson { get; set; } // The name of the corporation's contact person

        [Display(Name = "Contact Number")]
        [StringLength(50, ErrorMessage = "The contact number cannot be more than 50 characters.")]
        public string? Corp_ContactNo { get; set; } // The contact number of the corporation

        [Display(Name = "Fax Number")]
        [StringLength(20, ErrorMessage = "The fax number cannot be more than 20 characters.")]
        public string? Corp_fax { get; set; } // The fax number of the corporation

        [Display(Name = "Registration Number")]
        [StringLength(50, ErrorMessage = "The registration number cannot be more than 50 characters.")]
        public string? Corp_RegNo { get; set; } // The registration number of the corporation

        [Display(Name = "Tax Identification Number")]
        [StringLength(50, ErrorMessage = "The tax identification number cannot be more than 50 characters.")]
        public string? Corp_TIN { get; set; } // The tax identification number of the corporation

        [Required(ErrorMessage = "The bank is required.")]
        [Display(Name = "Bank")]
        public int BankID { get; set; } // The ID of the bank associated with the corporation

        [Display(Name = "Bank Account Number")]
        [StringLength(30, ErrorMessage = "The bank account number cannot be more than 30 characters.")]
        public string? BankAccNo { get; set; } // The bank account number of the corporation

        [Display(Name = "Corporate Group")]
        public int? CorpGroupID { get; set; } // The ID of the corporate group that the corporation belongs to

        [Display(Name = "Email Address")]
        [StringLength(400, ErrorMessage = "The email address cannot be more than 400 characters.")]
        [EmailAddress(ErrorMessage = "The email address is not valid.")]
        public string? Email { get; set; } // The email address of the corporation

        [Display(Name = "Finance Email Address")]
        [StringLength(200, ErrorMessage = "The finance email address cannot be more than 200 characters.")]
        [EmailAddress(ErrorMessage = "The finance email address is not valid.")]
        public string? FinanceEmail { get; set; } // The finance email address of the corporation

        [Required(ErrorMessage = "The suspension status is required.")]
        [Display(Name = "Is Suspended")]
        public bool IsSuspend { get; set; } // Indicates whether the corporation is suspended or not

        [Display(Name = "Industry Field")]
        public int? IndustryField { get; set; } // The industry field that the corporation operates in

        [Required(ErrorMessage = "The active status is required.")]
        [Display(Name = "Is Active")]
        public bool? IsActive { get; set; } // Indicates whether the corporation is active or not

        [Display(Name = "Created Date")]
        public DateTime? createdDate { get; set; } // The date that the corporation was created

        [Display(Name = "Last Modified By")]
        [StringLength(200, ErrorMessage = "The last modified by field cannot be more than 200 characters.")]
        public string? LastModifiedBy { get; set; } // The user who last modified the corporation

        [Display(Name = "Last Modified Date")]
        public DateTime? LastModifiedDate { get; set; } // The date that the corporation was last modified

        [Display(Name = "Bank")]
        public BankViewModel Bank { get; set; } // Navigation property to the bank associated with the corporation

        [Display(Name = "Corporate Group")]
        public virtual CorpGroupViewModel CorpGroup { get; set; } // Navigation property to the corporate group that the corporation belongs to

        [Display(Name = "Users")]
        public virtual ICollection<AppUser> Users { get; set; } = new List<AppUser>(); // Navigation property to the users associated with the corporation
    }


}
