using Microsoft.AspNetCore.Http;
using MudahMed.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.ViewModel.Emp
{
    public class EmployeeBulkUploadViewModel
    {
        public IFormFile File { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
