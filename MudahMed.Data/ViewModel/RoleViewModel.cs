using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.ViewModel
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        public bool IsAssigned { get; set; } // Flag to indicate if the role is assigned
    }

}
