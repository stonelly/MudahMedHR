using MudahMed.Data.DataContext;
using MudahMed.Data.Entities;
using MudahMed.Data.Repositories.Abstract;
using MudahMed.Data.ViewModel.Clinic;
using MudahMed.Data.ViewModel.Corporate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Repositories
{
    public class CorpUserRepository : ICorpUserRepository
    {
        private readonly DataDbContext _context;

        public CorpUserRepository(DataDbContext context)
        {
            _context = context;
        }

        // Get list of corporate users
        public async Task<List<CorpUserViewModel>> GetCorpUsersAsync()
        {
            return await _context.AppUsers
                .Where(u => u.RefTable == "tblCorp")
                .Select(u => new CorpUserViewModel
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    UserName = u.UserName,
                    Email = u.Email,
                    CorpID = (int)u.RefId,
                    // Map other properties as needed
                }).ToListAsync();
        }


        // Get a corporate user by ID
        public async Task<CorpUserViewModel> GetCorpUserByIdAsync(Guid userId)
        {
            var user = await _context.AppUsers.FindAsync(userId);
            if (user == null || user.RefTable != "tblCorp") return null;

            return new CorpUserViewModel
            {
                Id = user.Id,
                FullName = user.FullName,
                UserName = user.UserName,
                Email = user.Email,
                CorpID = (int)user.RefId,
                // Map other properties as needed
            };
        }


        // Create a corporate user
        public async Task CreateCorpUserAsync(CorpUserViewModel model)
        {
            var user = new AppUser
            {
                Id = Guid.NewGuid(),
                FullName = model.FullName,
                UserName = model.UserName,
                Email = model.Email,
                RefTable = "tblCorp",
                // Set other properties as needed
            };

            await _context.AppUsers.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        // Update a corporate user
        public async Task UpdateCorpUserAsync(CorpUserViewModel model)
        {
            var user = await _context.AppUsers.FindAsync(model.Id);
            if (user == null || user.RefTable != "tblCorp") return;

            user.FullName = model.FullName;
            user.UserName = model.UserName;
            user.Email = model.Email;
            // Update other properties as needed

            await _context.SaveChangesAsync();
        }

    }
}