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
        public int CorpID { get; set; }

        [StringLength(4000)]
        public string CorpName { get; set; }

        [StringLength(150)]
        public string CorpAddr1 { get; set; }

        [StringLength(150)]
        public string CorpAddr2 { get; set; }

        [StringLength(150)]
        public string CorpAddr3 { get; set; }

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
        public string CorpContactNo { get; set; }

        [StringLength(20)]
        public string CorpFax { get; set; }

        [StringLength(50)]
        public string CorpRegNo { get; set; }

        [StringLength(50)]
        public string CorpTIN { get; set; }

        [StringLength(20)]
        public string BankID { get; set; }

        [StringLength(30)]
        public string BankAccNo { get; set; }

        [Required]
        public int CorpGroupID { get; set; }

        [StringLength(400)]
        public string Email { get; set; }

        [StringLength(200)]
        public string FinanceEmail { get; set; }

        [Required]
        public bool IsSuspend { get; set; }

        public int? IndustryField { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(200)]
        public string LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public virtual CorpGroup CorpGroup { get; set; }
    }
}
