using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Entities
{
    public class Claim
    {
        [Key]
        public long ClaimID { get; set; }

        [Display(Name = "Clinic ID")]
        [StringLength(20)]
        public string ClinicID { get; set; }

        [Display(Name = "Employee ID")]
        public int? Emp_id { get; set; }

        [Display(Name = "Dependent ID")]
        public int? Dep_id { get; set; }

        [Display(Name = "Benefit ID")]
        [StringLength(10)]
        public string BenefitID { get; set; }

        [Display(Name = "Consultation Date")]
        public DateTime? ConsultDate { get; set; }

        [Display(Name = "Consultation Fee")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ConsultFee { get; set; }

        [Display(Name = "Medical Fee")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? MedFee { get; set; }

        [Display(Name = "X-Ray Fee")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? XrayFee { get; set; }

        [Display(Name = "Lab Fee")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? LabFee { get; set; }

        [Display(Name = "Injection Fee")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? InjectFee { get; set; }

        [Display(Name = "Surgery Fee")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? SurgFee { get; set; }

        [Display(Name = "Screening Fee")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ScreenFee { get; set; }

        [Display(Name = "Dressing Fee")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? DressFee { get; set; }

        [Display(Name = "Others Fee")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? OthersFee { get; set; }

        [Display(Name = "Referral Fee")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ReferFee { get; set; }

        [Display(Name = "Referral To")]
        [StringLength(100)]
        public string ReferTo { get; set; }

        [Display(Name = "Other Cost Remarks")]
        [StringLength(200)]
        public string OtherCostRmks { get; set; }

        [Display(Name = "Total Charge")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TotalCharge { get; set; }

        [Display(Name = "Company Pay")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? CompanyPay { get; set; }

        [Display(Name = "Employee Pay")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? EmpPay { get; set; }

        [Display(Name = "MC Type")]
        [StringLength(10)]
        public string MCType { get; set; }

        [Display(Name = "MC Day Given")]
        [Column(TypeName = "decimal(10, 1)")]
        public decimal? MCDayGiven { get; set; }

        [Display(Name = "MC Start Date")]
        public DateTime? MCStartDate { get; set; }

        [Display(Name = "MC Remarks")]
        [StringLength(100)]
        public string MCRemarks { get; set; }

        [Display(Name = "Claim Status")]
        [StringLength(20)]
        public string ClaimStatus { get; set; }

        [Display(Name = "DR Name")]
        [StringLength(100)]
        public string DRName { get; set; }

        [Display(Name = "Markup Amount")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? MarkupAmt { get; set; }

        [Display(Name = "Invoice ID")]
        [StringLength(20)]
        public string InvoiceID { get; set; }

        [Display(Name = "Bill Date")]
        public DateTime? BillDate { get; set; }

        [Display(Name = "Audit Remarks")]
        [StringLength(400)]
        public string AuditRemarks { get; set; }

        [Display(Name = "Is Audit")]
        public bool? IsAudit { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Last Modified By")]
        [StringLength(50)]
        public string LastModifiedBy { get; set; }

        [Display(Name = "Last Modified Date")]
        public DateTime? LastModifiedDate { get; set; }
    }

}
