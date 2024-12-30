using Microsoft.AspNetCore.Http;
using MudahMed.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.ViewModel.Dep
{
    public class DependentBulkUploadViewModel
    {
        public IFormFile File { get; set; }
        public List<Dependent> Dependents { get; set; } = new List<Dependent>();
    }
}
