using MudahMed.Data.ViewModel.Emp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Services.Abstract
{
    public interface IEmployeeService
    {
        Task<IQueryable<EmployeeViewModel>> GetAllEmployees();
        Task<EmployeeViewModel> GetEmployeeByIdAsync(int id);
        Task CreateEmployeeAsync(EmployeeViewModel model);
        Task UpdateEmployeeAsync(EmployeeViewModel model);
        Task DeleteEmployeeAsync(int id);
    }
}
