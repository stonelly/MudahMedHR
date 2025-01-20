using MudahMed.Data.ViewModel.Emp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Repositories.Abstract
{
    public interface IEmployeeRepository
    {
        Task<IQueryable<EmployeeViewModel>> GetEmployees();
        Task<EmployeeViewModel> GetEmployeeById(int id);
        Task CreateEmployeeAsync(EmployeeViewModel model);
        Task UpdateEmployeeAsync(EmployeeViewModel model);
        Task DeleteEmployeeAsync(int id);
    }
}
