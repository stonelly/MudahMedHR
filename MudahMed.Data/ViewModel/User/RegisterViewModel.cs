using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MudahMed.Data.ViewModel.User
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Full name")]
        [StringLength(100, ErrorMessage = "Can't exceed 100 characters.")]

        [Required]
        public string FullName { get; set; }
        [Display(Name = "Age")]
        [Range(0, 100, ErrorMessage = "Please enter valid age.")]
        public int? Age { get; set; }
        [Display(Name = "Phone")]
        [StringLength(12, ErrorMessage = "Please enter valid phonenumber.", MinimumLength = 9)]
        public string? Phone { get; set; }
        [Display(Name = "Address")]
        [StringLength(256, ErrorMessage = "Your address cannot be more than 200 characters.")]
        public string? Address { get; set; }
        public string UserRole { get; set; }

        public string RefTable { get; set; }
        [Required]
        public int RefId { get; set; }

        public bool TwoFactorEnabled { get; set; }
    }
}
