using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MudahMed.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        //User
        [Display(Name = "Full name")]
        [StringLength(100, ErrorMessage = "Full name cannot be more than 100 characters.")]
        public string? FullName { get; set; }
        [Display(Name = "Created date")]
        public DateTime? CreatedDate { get; set; }
        [Display(Name = "Created By")]
        public Guid? CreatedBy { get; set; }
        [Display(Name = "Modified date")]
        public DateTime? ModifiedDate { get; set; }
        [Display(Name = "Modified By")]
        public Guid? ModifiedBy { get; set; }
        public string? RefTable { get; set; } // Possible values: "tblCorp", "tblEmployee", "tblClinic"
        public int? RefId { get; set; } // Foreign key corresponding to the referenced table
        public int? Status { set; get; } // 0 = denied, 1 = waiting, 2 = confirmed, -1 = admin, null = default

    }
}