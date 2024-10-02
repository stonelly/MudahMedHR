using MudahMed.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Repositories.Abstract
{
    public interface IAppUserRepository
    {
        IList<AppUser> GetAll();

        Task<AppUser> GetById(Guid id);
    }
}
