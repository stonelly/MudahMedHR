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
    }
}
