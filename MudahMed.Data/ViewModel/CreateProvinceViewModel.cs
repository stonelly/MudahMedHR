﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MudahMed.Data.ViewModel
{
    public class CreateProvinceViewModel
    {
        [Required(ErrorMessage = "Please enter province name")]
        [StringLength(50, ErrorMessage = "The province name cannot be more than 50 characters.")]
        public string Name { get; set; }
    }
}
