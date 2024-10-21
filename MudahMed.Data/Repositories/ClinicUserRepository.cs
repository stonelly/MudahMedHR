using MudahMed.Data.DataContext;
using MudahMed.Data.Entities;
using MudahMed.Data.Repositories.Abstract;
using MudahMed.Data.ViewModel.Clinic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Repositories
{
    public class ClinicUserRepository : IClinicUserRepository
    {
        private readonly DataDbContext _context;

        public ClinicUserRepository(DataDbContext context)
        {
            _context = context;
        }

        // Get list of Clinicorate users
        public async Task<List<ClinicUserViewModel>> GetClinicUsersAsync()
        {
            return await _context.AppUsers
                .Where(u => u.RefTable == "tblClinic")
                .Select(u => new ClinicUserViewModel
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    UserName = u.UserName,
                    Email = u.Email,
                    ClinicID = (int)u.RefId,
                    // Map other properties as needed
                }).ToListAsync();
        }


        // Get a Clinicorate user by ID
        public async Task<ClinicUserViewModel> GetClinicUserByIdAsync(Guid userId)
        {
            var user = await _context.AppUsers.FindAsync(userId);
            if (user == null || user.RefTable != "tblClinic") return null;

            return new ClinicUserViewModel
            {
                Id = user.Id,
                FullName = user.FullName,
                UserName = user.UserName,
                Email = user.Email,
                ClinicID = (int)user.RefId,
                // Map other properties as needed
            };
        }


        // Create a Clinicorate user
        public async Task CreateClinicUserAsync(ClinicUserViewModel model)
        {
            var user = new AppUser
            {
                Id = Guid.NewGuid(),
                FullName = model.FullName,
                UserName = model.UserName,
                Email = model.Email,
                RefTable = "tblClinic",
                // Set other properties as needed
            };

            await _context.AppUsers.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        // Update a Clinicorate user
        public async Task UpdateClinicUserAsync(ClinicUserViewModel model)
        {
            var user = await _context.AppUsers.FindAsync(model.Id);
            if (user == null || user.RefTable != "tblClinic") return;

            user.FullName = model.FullName;
            user.UserName = model.UserName;
            user.Email = model.Email;
            // Update other properties as needed

            await _context.SaveChangesAsync();
        }

    }
}
