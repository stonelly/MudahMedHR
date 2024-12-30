using MudahMed.Data.DataContext;
using MudahMed.Data.Entities;
using MudahMed.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly DataDbContext _context;

        public AppUserRepository(DataDbContext context)
        {
            _context = context;
        }

        public IList<AppUser> GetAll()
        {
            return _context.AppUsers.ToList();
        }

        public async Task<AppUser> GetById(Guid id)
        {
            return await _context.AppUsers.FirstOrDefaultAsync(x => x.Id == id);
        }
        public IList<AppUser> GetUsersByRoleAsync(string roleName)
        {
            var role = _context.Roles.FirstOrDefault(r => r.Name == roleName);
            if (role == null)
            {
                return new List<AppUser>(); // Or handle this case as needed
            }

            var userIds = _context.UserRoles
                .Where(ur => ur.RoleId == role.Id)
                .Select(ur => ur.UserId)
                .ToList();

            //var users = _context.AppUsers
            //    .Where(u => userIds.Contains(u.Id))
            //    .ToList();
            var users = _context.AppUsers
                       .Where(u => userIds.Contains(u.Id))
                       .Select(u => new AppUser
                       {
                           Id = u.Id,
                           Email = u.Email,
                           FullName = u.FullName,
                           RefId = u.RefId,
                           RefTable = u.RefTable,
                           Status = u.Status,
                           CreatedBy = u.CreatedBy,
                           CreatedDate = u.CreatedDate,
                           ModifiedBy = u.ModifiedBy,
                           ModifiedDate = u.ModifiedDate,
                           UserName = u.UserName,
                           NormalizedEmail = u.NormalizedEmail,
                           EmailConfirmed = u.EmailConfirmed,
                           TwoFactorEnabled = u.TwoFactorEnabled,
                           LockoutEnabled = u.LockoutEnabled,
                           LockoutEnd = u.LockoutEnd,
                           AccessFailedCount = u.AccessFailedCount,
                           Corp = u.RefTable == "tblCorp" ? _context.Corps.FirstOrDefault(c => c.CorpID == u.RefId) : null,
                           Clinic = u.RefTable == "tblClinic" ? _context.Clinics.FirstOrDefault(c => c.ClinicID == u.RefId) : null
                       })
                       .ToList();

            return users;
        }
    }
}
