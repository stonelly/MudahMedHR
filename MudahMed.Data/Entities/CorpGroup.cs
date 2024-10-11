using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Entities
{
    public class CorpGroup
    {
        [Key]
        public int CorpGroupID { get; set; } // Primary Key

        [Display(Name = "Group Name")]
        [Required]
        [StringLength(100, ErrorMessage = "Group name is required and cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Display(Name = "Address Line 1")]
        [StringLength(150)]
        public string? Addr1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(150)]
        public string? Addr2 { get; set; }

        [Display(Name = "Address Line 3")]
        [StringLength(150)]
        public string? Addr3 { get; set; }

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
        public string? ContactNo { get; set; }

        [StringLength(20)]
        public string? Fax { get; set; }

        [StringLength(50)]
        public string? RegNo { get; set; }

        [StringLength(50)]
        public string? TIN { get; set; }

        [StringLength(20)]
        public string? BankID { get; set; }

        [StringLength(30)]
        public string? BankAccNo { get; set; }

        [StringLength(500)]
        public string? Email { get; set; }

        public DateTime? createdDate { get; set; }

        [StringLength(200)]
        public string? LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }
        public Bank Bank { get; set; } // Navigation property


        // Navigation property for related Corporations
        public virtual ICollection<Corp> Corporations { get; set; }
    }

}
