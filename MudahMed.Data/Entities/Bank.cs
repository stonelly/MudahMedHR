using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Entities
{
    public class Bank
    {
        public int Bank_id { get; set; } // Primary Key

        [Display(Name = "Bank Name")]
        [StringLength(100, ErrorMessage = "Bank name cannot be more than 100 characters.")]
        public string? Bank_name { get; set; }

        [Display(Name = "Is Display")]
        [Required]
        public bool IsDisplay { get; set; }
        public ICollection<Clinic> Clinics { get; set; } // Navigation property
        public ICollection<Corp> Corporations { get; set; } // Navigation property
        public ICollection<CorpGroup> CorpGroups { get; set; } // Navigation property
        public ICollection<Employee> Employees { get; set; } // Navigation property
    }
}
