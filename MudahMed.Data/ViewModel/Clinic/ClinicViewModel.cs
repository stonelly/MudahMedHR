using MudahMed.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.ViewModel.Clinic
{
    public class ClinicViewModel
    {
        // Clinic properties from Clinic table
        public int ClinicID { get; set; }
        [Display(Name = "Clinic Name")]
        public string? ClinicName { get; set; }
        [Display(Name = "Clinic Address 1")]
        public string? ClinicAddr1 { get; set; }
        [Display(Name = "Clinic Address 2")]
        public string? ClinicAddr2 { get; set; }
        [Display(Name = "Clinic Address 3")]
        public string? ClinicAddr3 { get; set; }

        [Display(Name = "Post Code")]
        public string? Postcode { get; set; }
        [Display(Name = "City")]
        public string? City { get; set; }
        [Display(Name = "State")]

        public string? State { get; set; }
        [Display(Name = "Country")]
        public string? Country { get; set; }
        [Display(Name = "Contact Person")]
        public string? ContactPerson { get; set; }
        [Display(Name = "Contact No")]
        public string? ClinicContactNo { get; set; }
        [Display(Name = "Fax")]
        public string? ClinicFax { get; set; }
        [Display(Name = "Registration Number")]
        public string? ClinicRegNo { get; set; }
        [Display(Name = "Clinic TIN")]
        public string? ClinicTIN { get; set; }

        [Display(Name = "Bank")]
        public int? BankID { get; set; }

        [Display(Name = "Bank Account")]
        public string? BankAccNo { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = "Recruit Date")]
        public DateTime? RecruitDate { get; set; }
        [Display(Name = "Removed Date")]
        public DateTime? RemovedDate { get; set; }
        [Display(Name = "Clinic Group")]
        public string? ClinicGroup { get; set; }
        [Display(Name = "Latitude")]
        public decimal Latitude { get; set; }
        [Display(Name = "Longitude")]
        public decimal Longitude { get; set; }
        [Display(Name = "Is 24Hour")]
        public bool Is24Hour { get; set; }
        [Display(Name = "Rendered Service")]
        public string? RenderedService { get; set; }
        [Display(Name = "Panel Type")]
        public string? PanelType { get; set; }
        [Display(Name = "Payee Name")]
        public string? PayeeName { get; set; }
        [Display(Name = "Handphone")]
        public string? Handphone { get; set; }
        [Display(Name = "Clinic Email")]
        public string? ClinicEmail { get; set; }
        [Display(Name = "Clinic Contact MMC")]
        public string? ClinicContMMC { get; set; }
        [Display(Name = "PermanentDoc1")]
        public string? PermanentDoc1 { get; set; }
        [Display(Name = "Permanent Doc1MMC")]
        public string? PermanentDoc1MMC { get; set; }
        [Display(Name = "Permanent Doc2")]
        public string? PermanentDoc2 { get; set; }
        [Display(Name = "Permanent Doc2MMC")]
        public string? PermanentDoc2MMC { get; set; }
        [Display(Name = "Locum Doc1")]
        public string? LocumDoc1 { get; set; }
        [Display(Name = "Locum Doc1MMC")]
        public string? LocumDoc1MMC { get; set; }
        [Display(Name = "Locum Doc2")]
        public string? LocumDoc2 { get; set; }
        [Display(Name = "Locum Doc2MMC")]
        public string? LocumDoc2MMC { get; set; }
        [Display(Name = "Clinic Contact OHD")]
        public string? ClinicContOHD { get; set; }
        [Display(Name = "Permanent Doc1OHD")]
        public string? PermanentDoc1OHD { get; set; }
        [Display(Name = "Permanent Doc2OHD")]
        public string? PermanentDoc2OHD { get; set; }
        [Display(Name = "Locum Doc1OHD")]
        public string? LocumDoc1OHD { get; set; }
        [Display(Name = "Locum Doc2OHD")]
        public string? LocumDoc2OHD { get; set; }
        [Display(Name = "SSM Number")]
        public string? SSMNo { get; set; }
        [Display(Name = "Is PCD")]
        public bool IsPCD { get; set; }
        [Display(Name = "Is IVD")]
        public bool IsIVD { get; set; }
        [Display(Name = "Is OT")]
        public bool IsOT { get; set; }
        [Display(Name = "Is CPR")]
        public bool IsCPR { get; set; }
        [Display(Name = "Is ENT")]
        public bool IsENT { get; set; }
        [Display(Name = "Is UFEME")]
        public bool IsUFEME { get; set; }
        [Display(Name = "Is Available AN")]
        public bool IsAvailAN { get; set; }
        [Display(Name = "Is Available MS")]
        public bool IsAvailMS { get; set; }
        [Display(Name = "Is Available Medical Check")]
        public bool IsAvailMC { get; set; }
        [Display(Name = "Is Spiro")]
        public bool IsSpiro { get; set; }
        [Display(Name = "Is Aud F")]
        public bool IsAudF { get; set; }
        [Display(Name = "Is Loc Doctor")]
        public bool IsLocDoc { get; set; }
        [Display(Name = "Is OHD Doctoct")]
        public bool IsOHDDoc { get; set; }
        [Display(Name = "Is Emergency")]
        public bool IsECG { get; set; }
        [Display(Name = "Is FB HAM")]
        public bool IsFBHAM { get; set; }
        [Display(Name = "Is Available Female Doctor")]
        public bool IsAvailFMDoc { get; set; }
        [Display(Name = "Is Nebulizer")]
        public bool IsNebulizer { get; set; }
        [Display(Name = "Is Ultra Sound")]
        public bool IsUltraSound { get; set; }
        [Display(Name = "Is Pap Sme")]
        public bool IsPapSme { get; set; }
        [Display(Name = "Is Xray Reader")]
        public bool IsXrayReader { get; set; }
        [Display(Name = "Is Xray")]
        public bool IsXray { get; set; }
        [Display(Name = "Modified By")]
        public string? LastModifiedBy { get; set; }
        [Display(Name = "Modified Date")]
        public DateTime? LastModifiedDate { get; set; }
        public virtual ICollection<AppUser> Users { get; set; } = new List<AppUser>();
    }


}
