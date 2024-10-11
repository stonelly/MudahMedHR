using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Entities
{
    public class Drug
    {
        [Display(Name = "Drug ID")]
        [Required(ErrorMessage = "Drug ID is required.")]
        public string DrugID { get; set; } // Primary Key

        [Display(Name = "Drug Type Code")]
        [Required(ErrorMessage = "Drug type code is required.")]
        public string DrugType_CodeFK { get; set; }

        [Display(Name = "Drug Category Code")]
        [Required(ErrorMessage = "Drug category code is required.")]
        public string DrugCatFFS_CodeFK { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please enter a description.")]
        [StringLength(500, ErrorMessage = "Description cannot be more than 500 characters.")]
        public string DrugDesc { get; set; }

        [Display(Name = "ATC Class")]
        [StringLength(20, ErrorMessage = "ATC Class cannot be more than 20 characters.")]
        public string? ATCClass { get; set; }

        [Display(Name = "MIMS Class Code")]
        [Required(ErrorMessage = "MIMS class code is required.")]
        public string DrugMIMSClass_CodeFK { get; set; }

        [Display(Name = "Generic Name")]
        [StringLength(500, ErrorMessage = "Generic name cannot be more than 500 characters.")]
        public string? GenericName { get; set; }

        [Display(Name = "Drug Route Code")]
        [Required(ErrorMessage = "Drug route code is required.")]
        public string DrugRoute_CodeFK { get; set; }

        [Display(Name = "Drug Unit Code")]
        [Required(ErrorMessage = "Drug unit code is required.")]
        public string DrugUnit_CodeFK { get; set; }

        [Display(Name = "ICD Code")]
        [StringLength(500, ErrorMessage = "ICD code cannot be more than 500 characters.")]
        public string? ICDCode { get; set; }

        [Display(Name = "Is Active")]
        public bool? IsActive { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Created By")]
        [StringLength(50, ErrorMessage = "Created by cannot be more than 50 characters.")]
        public string? CreatedBy { get; set; }

        [Display(Name = "Modified Date")]
        public DateTime? ModifyDate { get; set; }

        [Display(Name = "Modified By")]
        [StringLength(50, ErrorMessage = "Modified by cannot be more than 50 characters.")]
        public string? ModifyBy { get; set; }

        [Display(Name = "Charge Field Code")]
        public string? DrugChrgField_CodeFK { get; set; }

        [Display(Name = "Unit Price")]
        [Range(0, double.MaxValue, ErrorMessage = "Unit price must be a positive value.")]
        public decimal? UnitPrice { get; set; }

        [Display(Name = "Is Chronic")]
        public bool? IsChronic { get; set; }

        [Display(Name = "Maximum Quantity")]
        [Range(0, int.MaxValue, ErrorMessage = "Max quantity must be a non-negative value.")]
        public int? MaxQty { get; set; }

        [Display(Name = "Maximum Price")]
        [Range(0, double.MaxValue, ErrorMessage = "Max price must be a positive value.")]
        public decimal? MaxPrice { get; set; }

        [Display(Name = "Poison Code")]
        public string? DrugPoisonFFS_CodeFK { get; set; }

        [Display(Name = "Ceiling Price")]
        [Range(0, double.MaxValue, ErrorMessage = "Ceiling price must be a positive value.")]
        public decimal? CeilingPrice { get; set; }

        [Display(Name = "Is Exclusion")]
        public bool? IsExclusion { get; set; }

        // You can add navigation properties if you have related entities
        // public ICollection<RelatedEntity>? RelatedEntities { get; set; }
    }
}
