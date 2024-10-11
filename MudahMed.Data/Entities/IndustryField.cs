using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Entities
{
    public class IndustryField
    {
        [Key]
        public int ItemID { get; set; } // Primary Key

        [Display(Name = "Industry Field")]
        [StringLength(100, ErrorMessage = "Industry field cannot exceed 100 characters.")]
        public string? IndustryFieldName { get; set; }
    }
}
