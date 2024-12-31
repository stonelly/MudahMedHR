using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.ViewModel.Dep
{
    public class DependentViewModel
    {
        public int Dep_id { get; set; }

        [Required(ErrorMessage = "Employee ID is required.")]
        public int Emp_id { get; set; }

        [Display(Name = "Dependent Name")]
        [StringLength(100, ErrorMessage = "Dependent name cannot be more than 100 characters.")]
        public string? Dep_name { get; set; }

        [Display(Name = "Dependent IC")]
        [StringLength(30, ErrorMessage = "IC cannot be more than 30 characters.")]
        public string? Dep_ic { get; set; }

        [Display(Name = "Benefit ID")]
        [StringLength(10, ErrorMessage = "Benefit ID cannot be more than 10 characters.")]
        public string? BenefitID { get; set; }

        [Display(Name = "Relationship")]
        [StringLength(2, ErrorMessage = "Relationship cannot be more than 2 characters.")]
        public string? Relationship { get; set; }

        [Display(Name = "Gender")]
        [StringLength(1, ErrorMessage = "Gender cannot be more than 1 character.")]
        public string? Dep_gender { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? Dep_dob { get; set; }

        [Display(Name = "Race")]
        [StringLength(20, ErrorMessage = "Race cannot be more than 20 characters.")]
        public string? Dep_race { get; set; }

        [Display(Name = "Nationality")]
        [StringLength(50, ErrorMessage = "Nationality cannot be more than 50 characters.")]
        public string? Dep_nationality { get; set; }

        [Display(Name = "Join Date")]
        public DateTime? Join_dt { get; set; }

        [Display(Name = "Exit Date")]
        public DateTime? Ent_dt { get; set; }

        [Display(Name = "Client Number")]
        [StringLength(50, ErrorMessage = "Client number cannot be more than 50 characters.")]
        public string? ClientNumber { get; set; }

        [Display(Name = "Remarks")]
        [StringLength(100, ErrorMessage = "Remarks cannot be more than 100 characters.")]
        public string? Remarks { get; set; }

        [Display(Name = "Is Active")]
        public bool? IsActive { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Last Modified By")]
        [StringLength(30, ErrorMessage = "Last modified by cannot be more than 30 characters.")]
        public string? LastModifiedBy { get; set; }

        [Display(Name = "Last Modified Date")]
        public DateTime? LastModifiedDate { get; set; }

        [Display(Name = "Resignation Date")]
        public DateTime? DepResignDT { get; set; }

        [Display(Name = "Corporate ID")]
        [StringLength(20, ErrorMessage = "Corporate ID cannot be more than 20 characters.")]
        public string? CorpID { get; set; }
    }

}
