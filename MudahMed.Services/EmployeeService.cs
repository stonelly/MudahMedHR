using MudahMed.Data.Repositories.Abstract;
using MudahMed.Data.ViewModel.Emp;
using MudahMed.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IQueryable<EmployeeViewModel>> GetAllEmployees()
        {
            return await _employeeRepository.GetEmployees();
        }

        public async Task<EmployeeViewModel> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetEmployeeById(id);
        }

        public async Task CreateEmployeeAsync(EmployeeViewModel model)
        {
            await _employeeRepository.CreateEmployeeAsync(model);
        }

        public async Task UpdateEmployeeAsync(EmployeeViewModel model)
        {
            await _employeeRepository.UpdateEmployeeAsync(model);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
        }
    }
}
