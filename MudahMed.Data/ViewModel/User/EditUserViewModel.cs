using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MudahMed.Data.ViewModel.User
{
    public class EditUserViewModel
    {
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Full name")]
        [StringLength(100, ErrorMessage = "Can't exceed 100 characters.")]

        [Required]
        public string FullName { get; set; }
        public int? Age { get; set; }
        [Display(Name = "Phone")]
        [StringLength(12, ErrorMessage = "Please enter valid phonenumber.", MinimumLength = 9)]
        public string? Phone { get; set; }
        [Display(Name = "Address")]
        [StringLength(256, ErrorMessage = "Your address cannot be more than 200 characters.")]
        public string? Address { get; set; }
        public string UserRole { get; set; }

        public string? RefTable { get; set; }

        public int RefId { get; set; }

        public bool TwoFactorEnabled { get; set; }
    }
}
