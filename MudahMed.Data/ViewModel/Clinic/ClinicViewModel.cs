using MudahMed.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.ViewModel.Clinic
{
    public class ClinicViewModel
    {
        // Clinic properties from Clinic table
        public int ClinicID { get; set; }
        public string? ClinicName { get; set; }
        public string? ClinicAddr1 { get; set; }
        public string? ClinicAddr2 { get; set; }
        public string? ClinicAddr3 { get; set; }
        public string? Postcode { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ContactPerson { get; set; }
        public string? ClinicContactNo { get; set; }
        public string? ClinicFax { get; set; }
        public string? ClinicRegNo { get; set; }
        public string? ClinicTIN { get; set; }
        public int? BankID { get; set; }
        public string? BankAccNo { get; set; }
        public bool IsActive { get; set; }
        public DateTime? RecruitDate { get; set; }
        public DateTime? RemovedDate { get; set; }
        public string? ClinicGroup { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public bool? Is24Hour { get; set; }
        public string? RenderedService { get; set; }
        public string? PanelType { get; set; }
        public string? PayeeName { get; set; }
        public string? Handphone { get; set; }
        public string? ClinicEmail { get; set; }
        public string? ClinicContMMC { get; set; }
        public string? PermanentDoc1 { get; set; }
        public string? PermanentDoc1MMC { get; set; }
        public string? PermanentDoc2 { get; set; }
        public string? PermanentDoc2MMC { get; set; }
        public string? LocumDoc1 { get; set; }
        public string? LocumDoc1MMC { get; set; }
        public string? LocumDoc2 { get; set; }
        public string? LocumDoc2MMC { get; set; }
        public string? ClinicContOHD { get; set; }
        public string? PermanentDoc1OHD { get; set; }
        public string? PermanentDoc2OHD { get; set; }
        public string? LocumDoc1OHD { get; set; }
        public string? LocumDoc2OHD { get; set; }
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

        public virtual ICollection<AppUser> Users { get; set; } = new List<AppUser>();
    }


}
