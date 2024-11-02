using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.ViewModel.General
{
    public class CodeMasterViewModel
    {
        public int CodeMaster_id { get; set; } // Primary Key (Auto-increment)

        [Display(Name = "CodeType")]
        [StringLength(30, ErrorMessage = "Code Type cannot be more than 30 characters.")]
        [Required]
        public string? CodeType { get; set; }

        [Display(Name = "Code Value")]
        [StringLength(200, ErrorMessage = "Code Value cannot be more than 200 characters.")]
        [Required]
        public string? CodeValue { get; set; }

        [Display(Name = "Code Description")]
        [StringLength(500, ErrorMessage = "Code Description cannot be more than 500 characters.")]
        [Required]
        public string? CodeDescription { get; set; }

        [Display(Name = "Sequence")]
        public int? Sequence { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [Display(Name = "Created By")]
        [StringLength(50, ErrorMessage = "Created by cannot be more than 50 characters.")]
        public string? CreatedDateBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Last Modified By")]
        [StringLength(50, ErrorMessage = "Last modified by cannot be more than 50 characters.")]
        public string? LastModifiedBy { get; set; }

        [Display(Name = "Last Modified Date")]
        public DateTime? LastModifiedDate { get; set; }
    }
}
