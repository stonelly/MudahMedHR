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

            var users = _context.AppUsers
                .Where(u => userIds.Contains(u.Id))
                .ToList();

            return users;
        }
    }
}
