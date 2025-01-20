using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MudahMed.Data.DataContext;
using MudahMed.Data.Entities;
using MudahMed.Data.Repositories.Abstract;
using MudahMed.Data.ViewModel.Emp;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Repositories
{

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmployeeRepository(DataDbContext context, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        // Get all employees
        public Task<IQueryable<EmployeeViewModel>> GetEmployees()
        {
            return Task.FromResult(_context.Employees.Where(c => c.IsActive ?? false == true)
                .Select(e => new EmployeeViewModel
                {
                    Emp_id = e.Emp_id,
                    Emp_ic = e.Emp_ic,
                    Emp_name = e.Emp_name,
                    CorpID = e.CorpID,
                    Suboffice_fk = e.Suboffice_fk,
                    Dept_fk = e.Dept_fk,
                    BenefitID = e.BenefitID,
                    Emp_gender = e.Emp_gender,
                    Emp_dob = e.Emp_dob,
                    Emp_race = e.Emp_race,
                    Emp_nationality = e.Emp_nationality,
                    Addr1 = e.Addr1,
                    Addr2 = e.Addr2,
                    Addr3 = e.Addr3,
                    Postcode = e.Postcode,
                    City = e.City,
                    State = e.State,
                    Country = e.Country,
                    Email = e.Email,
                    Cont_no = e.Cont_no,
                    Designation = e.Designation,
                    Remarks = e.Remarks,
                    Join_dt = e.Join_dt,
                    Ent_dt = e.Ent_dt,
                    BankID = e.BankID,
                    BankAccNo = e.BankAccNo,
                    Resign_dt = e.Resign_dt,
                    ClientNumber = e.ClientNumber,
                    CostCentre = e.CostCentre,
                    IsActive = e.IsActive ?? false,
                    CreatedDate = e.CreatedDate,
                    LastModifiedBy = e.LastModifiedBy,
                    LastModifiedDate = e.LastModifiedDate,
                    Dependents = e.Dependents
                }));
        }

        // Get an employee by ID
        public async Task<EmployeeViewModel> GetEmployeeById(int id)
        { 
            var employee = await _context.Employees.FindAsync(id); 

            if (employee == null) return new EmployeeViewModel();

            return new EmployeeViewModel
            {
                Emp_id = employee.Emp_id,
                Emp_ic = employee.Emp_ic,
                Emp_name = employee.Emp_name,
                CorpID = employee.CorpID,
                Suboffice_fk = employee.Suboffice_fk,
                Dept_fk = employee.Dept_fk,
                BenefitID = employee.BenefitID,
                Emp_gender = employee.Emp_gender,
                Emp_dob = employee.Emp_dob,
                Emp_race = employee.Emp_race,
                Emp_nationality = employee.Emp_nationality,
                Addr1 = employee.Addr1,
                Addr2 = employee.Addr2,
                Addr3 = employee.Addr3,
                Postcode = employee.Postcode,
                City = employee.City,
                State = employee.State,
                Country = employee.Country,
                Email = employee.Email,
                Cont_no = employee.Cont_no,
                Designation = employee.Designation,
                Remarks = employee.Remarks,
                Join_dt = employee.Join_dt,
                Ent_dt = employee.Ent_dt,
                BankID = employee.BankID,
                BankAccNo = employee.BankAccNo,
                Resign_dt = employee.Resign_dt,
                ClientNumber = employee.ClientNumber,
                CostCentre = employee.CostCentre,
                IsActive = employee.IsActive ?? false,
                CreatedDate = employee.CreatedDate,
                LastModifiedBy = employee.LastModifiedBy,
                LastModifiedDate = employee.LastModifiedDate,
                Dependents = employee.Dependents
            };
        }

        // Create a new employee
        public async Task CreateEmployeeAsync(EmployeeViewModel model)
        {

            var employee = new Employee
            {
                Emp_ic = model.Emp_ic,
                Emp_name = model.Emp_name,
                CorpID = model.CorpID,
                Suboffice_fk = model.Suboffice_fk,
                Dept_fk = model.Dept_fk,
                BenefitID = model.BenefitID,
                Emp_gender = model.Emp_gender,
                Emp_dob = model.Emp_dob,
                Emp_race = model.Emp_race,
                Emp_nationality = model.Emp_nationality,
                Addr1 = model.Addr1,
                Addr2 = model.Addr2,
                Addr3 = model.Addr3,
                Postcode = model.Postcode,
                City = model.City,
                State = model.State,
                Country = model.Country,
                Email = model.Email,
                Cont_no = model.Cont_no,
                Designation = model.Designation,
                Remarks = model.Remarks,
                Join_dt = model.Join_dt,
                Ent_dt = model.Ent_dt,
                BankID = model.BankID,
                BankAccNo = model.BankAccNo,
                Resign_dt = model.Resign_dt,
                ClientNumber = model.ClientNumber,
                CostCentre = model.CostCentre,
                IsActive = true,
                CreatedDate = DateTime.Now,
                LastModifiedBy = _userManager.GetUserId(_httpContextAccessor.HttpContext.User)
            };

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

        }

        // Update an existing employee
        public async Task UpdateEmployeeAsync(EmployeeViewModel model)
        {
            var employee = await _context.Employees.FindAsync(model.Emp_id);
            if (employee == null) return;

            employee.Emp_ic = model.Emp_ic;
            employee.Emp_name = model.Emp_name;
            employee.CorpID = model.CorpID;
            employee.Suboffice_fk = model.Suboffice_fk;
            employee.Dept_fk = model.Dept_fk;
            employee.BenefitID = model.BenefitID;
            employee.Emp_gender = model.Emp_gender;
            employee.Emp_dob = model.Emp_dob;
            employee.Emp_race = model.Emp_race;
            employee.Emp_nationality = model.Emp_nationality;
            employee.Addr1 = model.Addr1;
            employee.Addr2 = model.Addr2;
            employee.Addr3 = model.Addr3;
            employee.Postcode = model.Postcode;
            employee.City = model.City;
            employee.State = model.State;
            employee.Country = model.Country;
            employee.Email = model.Email;
            employee.Cont_no = model.Cont_no;
            employee.Designation = model.Designation;
            employee.Remarks = model.Remarks;
            employee.Join_dt = model.Join_dt;
            employee.Ent_dt = model.Ent_dt;
            employee.BankID = model.BankID;
            employee.BankAccNo = model.BankAccNo;
            employee.Resign_dt = model.Resign_dt;
            employee.ClientNumber = model.ClientNumber;
            employee.CostCentre = model.CostCentre;
            employee.IsActive = model.IsActive;
            employee.LastModifiedBy = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            employee.LastModifiedDate = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        // Delete an employee
        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}
