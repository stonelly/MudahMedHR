using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.ViewModel.Clinic
{
    public class DiagnosisViewModel
    {
        [Display(Name = "Diagnosis ID")]
        [Required(ErrorMessage = "Diagnosis ID is required.")]
        public string Diag_id { get; set; } // Primary Key

        [Display(Name = "Diagnosis Category")]
        public string? Diag_cat { get; set; }

        [Display(Name = "Diagnosis Description")]
        [StringLength(200, ErrorMessage = "Description cannot be more than 200 characters.")]
        public string? Diag_desc { get; set; }

        [Display(Name = "Is Remarks Required")]
        [Required(ErrorMessage = "Indicate if remarks are required.")]
        public bool IsRemarksReq { get; set; }

        [Display(Name = "Is Active")]
        [Required(ErrorMessage = "Indicate if the diagnosis is active.")]
        public bool IsActive { get; set; }

        [Display(Name = "Is LTM")]
        [Required(ErrorMessage = "Indicate if it is a long-term medication.")]
        public bool IsLTM { get; set; }

        [Display(Name = "Is GP")]
        public bool IsGP { get; set; }

        [Display(Name = "Diagnosis Group")]
        [StringLength(200, ErrorMessage = "Diagnosis group cannot be more than 200 characters.")]
        public string? DiagGrp { get; set; }
    }
}
