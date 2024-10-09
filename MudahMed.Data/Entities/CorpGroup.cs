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
        public int CorpGroupID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter Group Corporation name")]
        [StringLength(100, ErrorMessage = "Group Corporation name cannot be more than 100 characters.")]
        public string Name { get; set; }


        [Display(Name = "Address 1")]
        [StringLength(150)]
        public string Addr1 { get; set; }

        [Display(Name = "Address 2")]
        [StringLength(150)]
        public string Addr2 { get; set; }

        [Display(Name = "Address 3")]
        [StringLength(150)]
        public string Addr3 { get; set; }

        [Display(Name = "Postcode")]
        [StringLength(10)]
        public string Postcode { get; set; }

        [Display(Name = "City")]
        [StringLength(100)]
        public string City { get; set; }

        [Display(Name = "State")]
        [StringLength(50)]
        public string State { get; set; }

        [Display(Name = "Country")]
        [StringLength(100)]
        public string Country { get; set; }

        [Display(Name = "Contact Person")]
        [StringLength(100)]
        public string ContactPerson { get; set; }

        [Display(Name = "Contact No")]
        [StringLength(50)]
        public string ContactNo { get; set; }

        [Display(Name = "Fax")]
        [StringLength(20)]
        public string Fax { get; set; }

        [Display(Name = "Registration No")]
        [StringLength(50)]
        public string RegNo { get; set; }

        [Display(Name = "TIN")]
        [StringLength(50)]
        public string TIN { get; set; }

        [Display(Name = "Bank ID")]
        [StringLength(20)]
        public string BankID { get; set; }

        [Display(Name = "Bank Account No")]
        [StringLength(30)]
        public string BankAccNo { get; set; }

        [Display(Name = "Email")]
        [StringLength(500)]
        public string Email { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Modified By")]
        [StringLength(200)]
        public string LastModifiedBy { get; set; }

        [Display(Name = "Modified Date")]
        public DateTime? LastModifiedDate { get; set; }

        // Navigation property for related Corporations
        public virtual ICollection<Corp> Corporations { get; set; }
    }

}
