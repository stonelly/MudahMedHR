using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MudahMed.Data.DataContext;
using MudahMed.Data.Entities;
using MudahMed.Data.Repositories.Abstract;
using MudahMed.Data.ViewModel.Dep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Repositories
{
    public class DependentRepository : IDependentRepository
    {
        private readonly DataDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DependentRepository(DataDbContext context, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        // Get all dependents
        public Task<IQueryable<DependentViewModel>> GetDependents()
        {
            return Task.FromResult(_context.Dependents
                .Select(d => new DependentViewModel
                {
                    Dep_id = d.Dep_id,
                    Emp_id = d.Emp_id,
                    Dep_name = d.Dep_name,
                    Dep_ic = d.Dep_ic,
                    BenefitID = d.BenefitID,
                    Relationship = d.Relationship,
                    Dep_gender = d.Dep_gender,
                    Dep_dob = d.Dep_dob,
                    Dep_race = d.Dep_race,
                    Dep_nationality = d.Dep_nationality,
                    Join_dt = d.Join_dt,
                    Ent_dt = d.Ent_dt,
                    ClientNumber = d.ClientNumber,
                    Remarks = d.Remarks,
                    IsActive = d.IsActive ?? false,
                    CreatedDate = d.CreatedDate,
                    LastModifiedBy = d.LastModifiedBy,
                    LastModifiedDate = d.LastModifiedDate,
                    DepResignDT = d.DepResignDT,
                    Employee = d.Employee
                }));
        }

        // Get a dependent by ID
        public async Task<DependentViewModel> GetDependentById(int id)
        {
            var dependent = await _context.Dependents.FindAsync(id); 

            if (dependent == null) return new DependentViewModel();

            return new DependentViewModel
            {
                Dep_id = dependent.Dep_id,
                Emp_id = dependent.Emp_id,
                Dep_name = dependent.Dep_name,
                Dep_ic = dependent.Dep_ic,
                BenefitID = dependent.BenefitID,
                Relationship = dependent.Relationship,
                Dep_gender = dependent.Dep_gender,
                Dep_dob = dependent.Dep_dob,
                Dep_race = dependent.Dep_race,
                Dep_nationality = dependent.Dep_nationality,
                Join_dt = dependent.Join_dt,
                Ent_dt = dependent.Ent_dt,
                ClientNumber = dependent.ClientNumber,
                Remarks = dependent.Remarks,
                IsActive = dependent.IsActive ?? false,
                CreatedDate = dependent.CreatedDate,
                LastModifiedBy = dependent.LastModifiedBy,
                LastModifiedDate = dependent.LastModifiedDate,
                DepResignDT = dependent.DepResignDT,
                Employee = dependent.Employee
            };
        }

        // Create a new dependent
        public async Task CreateDependentAsync(DependentViewModel model)
        {
            var dependent = new Dependent
            {
                Emp_id = model.Emp_id,
                Dep_name = model.Dep_name,
                Dep_ic = model.Dep_ic,
                BenefitID = model.BenefitID,
                Relationship = model.Relationship,
                Dep_gender = model.Dep_gender,
                Dep_dob = model.Dep_dob,
                Dep_race = model.Dep_race,
                Dep_nationality = model.Dep_nationality,
                Join_dt = model.Join_dt,
                Ent_dt = model.Ent_dt,
                ClientNumber = model.ClientNumber,
                Remarks = model.Remarks,
                IsActive = true,
                CreatedDate = DateTime.Now,
                LastModifiedBy = _userManager.GetUserId(_httpContextAccessor.HttpContext.User)
            };

            await _context.Dependents.AddAsync(dependent);
            await _context.SaveChangesAsync();
        }

        // Update an existing dependent
        public async Task UpdateDependentAsync(DependentViewModel model)
        {
            var dependent = await _context.Dependents.FindAsync(model.Dep_id);
            if (dependent == null) return;

            dependent.Emp_id = model.Emp_id;
            dependent.Dep_name = model.Dep_name;
            dependent.Dep_ic = model.Dep_ic;
            dependent.BenefitID = model.BenefitID;
            dependent.Relationship = model.Relationship;
            dependent.Dep_gender = model.Dep_gender;
            dependent.Dep_dob = model.Dep_dob;
            dependent.Dep_race = model.Dep_race;
            dependent.Dep_nationality = model.Dep_nationality;
            dependent.Join_dt = model.Join_dt;
            dependent.Ent_dt = model.Ent_dt;
            dependent.ClientNumber = model.ClientNumber;
            dependent.Remarks = model.Remarks;
            dependent.IsActive = model.IsActive;
            dependent.LastModifiedBy = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            dependent.LastModifiedDate = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        // Delete a dependent
        public async Task DeleteDependentAsync(int id)
        {
            var dependent = await _context.Dependents.FindAsync(id);
            if (dependent == null) return;

            _context.Dependents.Remove(dependent);
            await _context.SaveChangesAsync();
        }
    }
}
