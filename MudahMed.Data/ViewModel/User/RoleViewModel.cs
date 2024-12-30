using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.ViewModel.User
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Encrypted Key")]
        public string EncryptedKey { get; set; }
        public bool IsAssigned { get; set; } // Flag to indicate if the role is assigned
    }

}
