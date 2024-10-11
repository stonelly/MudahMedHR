using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.ViewModel.Bank
{
    public class BankViewModel
    {
        public int BankID { get; set; }

        [Display(Name = "Bank Name")]
        [Required(ErrorMessage = "Please enter the bank name.")]
        [StringLength(100, ErrorMessage = "Bank name cannot exceed 100 characters.")]
        public string BankName { get; set; }

        [Display(Name = "Is Display")]
        public bool IsDisplay { get; set; }

        public bool IsAssigned { get; set; } // Optional flag to indicate if the bank is assigned
    }
}
