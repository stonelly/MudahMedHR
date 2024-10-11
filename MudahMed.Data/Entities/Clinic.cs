using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Entities
{
    public class Clinic
    {
        [Key]
        public string ClinicID { get; set; } // Primary Key

        [Display(Name = "Clinic Name")]
        [StringLength(100, ErrorMessage = "Clinic name cannot be more than 100 characters.")]
        public string? Clinic_name { get; set; }

        [Display(Name = "Address Line 1")]
        [StringLength(150)]
        public string? Clinic_addr1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(150)]
        public string? Clinic_addr2 { get; set; }

        [Display(Name = "Address Line 3")]
        [StringLength(150)]
        public string? Clinic_addr3 { get; set; }

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

        public int? BankID { get; set; }

        [StringLength(30)]
        public string? BankAccNo { get; set; }

        [StringLength(10)]
        public string? rendered_svc { get; set; }

        [StringLength(10)]
        public string? panel_type { get; set; }

        [StringLength(100)]
        public string? PayeeName { get; set; }

        [StringLength(20)]
        public string? Handphone { get; set; }

        [StringLength(200)]
        public string? Email { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public DateTime? RecruitDate { get; set; }
        public DateTime? RemovedDate { get; set; }

        [StringLength(100)]
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        [StringLength(100)]
        public string? ClinicGroup { get; set; }

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        public bool? Is24Hour { get; set; }

        [StringLength(50)]
        public string? Clinic_cont_MMC { get; set; }

        [StringLength(200)]
        public string? PermenantDoc1 { get; set; }

        [StringLength(50)]
        public string? PermenantDoc1MMC { get; set; }

        [StringLength(200)]
        public string? PermenantDoc2 { get; set; }

        [StringLength(50)]
        public string? PermenantDoc2MMC { get; set; }

        [StringLength(200)]
        public string? LocumDoc1 { get; set; }

        [StringLength(50)]
        public string? LocumDoc1MMC { get; set; }

        [StringLength(200)]
        public string? LocumDoc2 { get; set; }

        [StringLength(50)]
        public string? LocumDoc2MMC { get; set; }

        [StringLength(20)]
        public string? Clinic_cont_OHD { get; set; }

        [StringLength(20)]
        public string? PermenantDoc1OHD { get; set; }

        [StringLength(20)]
        public string? PermenantDoc2OHD { get; set; }

        [StringLength(20)]
        public string? LocumDoc1OHD { get; set; }

        [StringLength(20)]
        public string? LocumDoc2OHD { get; set; }

        [StringLength(100)]
        public string? SSMNo { get; set; }

        public bool? IsPCD { get; set; }
        public bool? IsIVD { get; set; }
        public bool? IsOT { get; set; }
        public bool? IsCPR { get; set; }
        public bool? IsENT { get; set; }
        public bool? IsUFEME { get; set; }
        public bool? IsAvailAN { get; set; }
        public bool? IsAvailMS { get; set; }
        public bool? IsAvailMC { get; set; }
        public bool? IsSpiro { get; set; }
        public bool? IsAudF { get; set; }
        public bool? IsLocDoc { get; set; }
        public bool? IsOHDDoc { get; set; }
        public bool? IsECG { get; set; }
        public bool? IsFBHAM { get; set; }
        public bool? IsAvailFMDoc { get; set; }
        public bool? IsNebulizer { get; set; }
        public bool? IsUltraSound { get; set; }
        public bool? IsPapSme { get; set; }
        public bool? IsXrayReader { get; set; }
        public bool? IsXray { get; set; }
        public Bank Bank { get; set; } // Navigation property

    }
}
