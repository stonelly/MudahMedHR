using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Entities
{
    public class Employee
    {
        public int Emp_id { get; set; } // Primary Key (Auto-increment)

        [Display(Name = "IC Number")]
        [StringLength(30, ErrorMessage = "IC number cannot be more than 30 characters.")]
        public string? Emp_ic { get; set; }

        [Display(Name = "Name")]
        [StringLength(100, ErrorMessage = "Name cannot be more than 100 characters.")]
        public string? Emp_name { get; set; }

        [Display(Name = "Corporate ID")]
        [StringLength(20, ErrorMessage = "Corporate ID cannot be more than 20 characters.")]
        public string? CorpID { get; set; }

        [Display(Name = "Suboffice")]
        [StringLength(20, ErrorMessage = "Suboffice cannot be more than 20 characters.")]
        public string? Suboffice_fk { get; set; }

        [Display(Name = "Department")]
        [StringLength(20, ErrorMessage = "Department cannot be more than 20 characters.")]
        public string? Dept_fk { get; set; }

        [Display(Name = "Benefit ID")]
        [StringLength(10, ErrorMessage = "Benefit ID cannot be more than 10 characters.")]
        public string? BenefitID { get; set; }

        [Display(Name = "Gender")]
        [StringLength(1, ErrorMessage = "Gender cannot be more than 1 character.")]
        public string? Emp_gender { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? Emp_dob { get; set; }

        [Display(Name = "Race")]
        [StringLength(20, ErrorMessage = "Race cannot be more than 20 characters.")]
        public string? Emp_race { get; set; }

        [Display(Name = "Nationality")]
        [StringLength(50, ErrorMessage = "Nationality cannot be more than 50 characters.")]
        public string? Emp_nationality { get; set; }

        [Display(Name = "Address Line 1")]
        [StringLength(150, ErrorMessage = "Address cannot be more than 150 characters.")]
        public string? Addr1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(150, ErrorMessage = "Address cannot be more than 150 characters.")]
        public string? Addr2 { get; set; }

        [Display(Name = "Address Line 3")]
        [StringLength(150, ErrorMessage = "Address cannot be more than 150 characters.")]
        public string? Addr3 { get; set; }

        [Display(Name = "Postcode")]
        [StringLength(10, ErrorMessage = "Postcode cannot be more than 10 characters.")]
        public string? Postcode { get; set; }

        [Display(Name = "City")]
        [StringLength(100, ErrorMessage = "City cannot be more than 100 characters.")]
        public string? City { get; set; }

        [Display(Name = "State")]
        [StringLength(50, ErrorMessage = "State cannot be more than 50 characters.")]
        public string? State { get; set; }

        [Display(Name = "Country")]
        [StringLength(100, ErrorMessage = "Country cannot be more than 100 characters.")]
        public string? Country { get; set; }

        [Display(Name = "Email")]
        [StringLength(100, ErrorMessage = "Email cannot be more than 100 characters.")]
        public string? Email { get; set; }

        [Display(Name = "Contact Number")]
        [StringLength(30, ErrorMessage = "Contact number cannot be more than 30 characters.")]
        public string? Cont_no { get; set; }

        [Display(Name = "Designation")]
        [StringLength(100, ErrorMessage = "Designation cannot be more than 100 characters.")]
        public string? Designation { get; set; }

        [Display(Name = "Remarks")]
        [StringLength(100, ErrorMessage = "Remarks cannot be more than 100 characters.")]
        public string? Remarks { get; set; }

        [Display(Name = "Join Date")]
        public DateTime? Join_dt { get; set; }

        [Display(Name = "Exit Date")]
        public DateTime? Ent_dt { get; set; }

        [Display(Name = "Bank ID")]
        [StringLength(100, ErrorMessage = "Bank ID cannot be more than 100 characters.")]
        public string? BankID { get; set; }

        [Display(Name = "Bank Account Number")]
        [StringLength(30, ErrorMessage = "Bank account number cannot be more than 30 characters.")]
        public string? BankAccNo { get; set; }

        [Display(Name = "Resignation Date")]
        public DateTime? Resign_dt { get; set; }

        [Display(Name = "Client Number")]
        [StringLength(50, ErrorMessage = "Client number cannot be more than 50 characters.")]
        public string? ClientNumber { get; set; }

        [Display(Name = "Cost Centre")]
        [StringLength(100, ErrorMessage = "Cost centre cannot be more than 100 characters.")]
        public string? CostCentre { get; set; }

        [Display(Name = "Is Active")]
        public bool? IsActive { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Last Modified By")]
        [StringLength(20, ErrorMessage = "Last modified by cannot be more than 20 characters.")]
        public string? LastModifiedBy { get; set; }

        [Display(Name = "Last Modified Date")]
        public DateTime? LastModifiedDate { get; set; }
        public Bank Bank { get; set; } // Navigation property

        // Navigation property to Dependents
        public virtual ICollection<Dependent> Dependents { get; set; } = new List<Dependent>();

    }
}
