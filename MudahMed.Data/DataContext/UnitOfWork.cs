using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.DataContext
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataDbContext _context;

        public UnitOfWork(DataDbContext context)
        {
            _context = context;
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
