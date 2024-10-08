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

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Addr1 { get; set; }

        [StringLength(150)]
        public string Addr2 { get; set; }

        [StringLength(150)]
        public string Addr3 { get; set; }

        [StringLength(10)]
        public string Postcode { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        [StringLength(100)]
        public string ContactPerson { get; set; }

        [StringLength(50)]
        public string ContactNo { get; set; }

        [StringLength(20)]
        public string Fax { get; set; }

        [StringLength(50)]
        public string RegNo { get; set; }

        [StringLength(50)]
        public string TIN { get; set; }

        [StringLength(20)]
        public string BankID { get; set; }

        [StringLength(30)]
        public string BankAccNo { get; set; }

        [StringLength(500)]
        public string Email { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(200)]
        public string LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        // Navigation property for related Corporations
        public virtual ICollection<Corp> Corporations { get; set; }
    }

}
