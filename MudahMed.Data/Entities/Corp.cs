using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Entities
{
    public class Corp
    {
        [Key]
        public int CorpID { get; set; } // Primary Key

        [Display(Name = "Corporate Name")]
        [StringLength(4000, ErrorMessage = "Corporate name cannot be more than 4000 characters.")]
        public string? Corp_name { get; set; }

        [Display(Name = "Address Line 1")]
        [StringLength(150)]
        public string? Corp_addr1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(150)]
        public string? Corp_addr2 { get; set; }

        [Display(Name = "Address Line 3")]
        [StringLength(150)]
        public string? Corp_addr3 { get; set; }

        [StringLength(10)]
        public string? postcode { get; set; }

        [StringLength(100)]
        public string? city { get; set; }

        [StringLength(50)]
        public string? state { get; set; }

        [StringLength(100)]
        public string? country { get; set; }

        [StringLength(100)]
        public string? ContactPerson { get; set; }

        [StringLength(50)]
        public string? Corp_ContactNo { get; set; }

        [StringLength(20)]
        public string? Corp_fax { get; set; }

        [StringLength(50)]
        public string? Corp_RegNo { get; set; }

        [StringLength(50)]
        public string? Corp_TIN { get; set; }

        [StringLength(20)]
        public string? BankID { get; set; }

        [StringLength(30)]
        public string? BankAccNo { get; set; }

        public int? CorpGroupID { get; set; }

        [StringLength(400)]
        public string? Email { get; set; }

        [StringLength(200)]
        public string? FinanceEmail { get; set; }

        [Required]
        public bool IsSuspend { get; set; }

        public int? IndustryField { get; set; }

        public DateTime? createdDate { get; set; }

        [StringLength(200)]
        public string? LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }
        public Bank Bank { get; set; } // Navigation property

        public virtual CorpGroup CorpGroup { get; set; }
    }

}
